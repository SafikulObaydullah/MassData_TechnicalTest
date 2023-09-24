using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Repository.Contracts;
using EntityFrameworkCore.RawSQLExtensions.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BMTLLMS.Repository.Implementations
{
   public class SampleReceiveRepository : ISampleReceiveRepo
   {
      private readonly RavenDBContext _db;
      public SampleReceiveRepository(RavenDBContext db)
      {
         _db = db;
      }
      public IEnumerable<OrderDetailsListVM> GetOrderDetailList(SampleReceiveSearchListVM obj)
      {
         var OrderRefNo = new SqlParameter
         {
            ParameterName = "OrderRefNo",
            Value = obj.OrderRefNo
         };
         var OrderDateFrom = new SqlParameter
         {
            ParameterName = "OrderDateFrom",
            Value = obj.OrderDateFrom
         };
         var OrderDateTo = new SqlParameter
         {
            ParameterName = "OrderDateTo",
            Value = obj.OrderDateTo
         };
         var CustomerID = new SqlParameter
         {
            ParameterName = "CustomerID",
            Value = obj.CustomerID
         };
         var StatusID = new SqlParameter
         {
            ParameterName = "StatusID",
            Value = obj.StatusID
         };
         var DeliveryDateFrom = new SqlParameter
         {
            ParameterName = "DeliveryDateFrom",
            Value = obj.DeliveryDateFrom
         };
         var DeliveryDateTo = new SqlParameter
         {
            ParameterName = "DeliveryDateTo",
            Value = obj.DeliveryDateTo
         }; 
         var SPname = "GetOrderDetailsList " + obj.OrderRefNo + ",'" + obj.OrderDateFrom + "','" + obj.OrderDateTo + "'," + obj.CustomerID + "," + obj.StatusID + ",'" + obj.DeliveryDateFrom + "'" +
             ",'" + obj.DeliveryDateTo + "'";
         var results = _db.Database.SqlQuery<OrderDetailsListVM>(SPname).ToList();
         return results;
      }
      public SaveVM SaveSampleReceive(SampleReceiveVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var SampleID = new SqlParameter
            {
               ParameterName = "SampleID",
               Value = obj.SampleID == null ? DBNull.Value : obj.SampleID
            };
            var SampleConditionID = new SqlParameter
            {
               ParameterName = "SampleConditionID",
               Value = obj.SampleConditionID == null ? DBNull.Value : obj.SampleConditionID
            };
            var SpecificationID = new SqlParameter
            {
               ParameterName = "SpecificationID",
               Value = obj.SpecificationID == null ? DBNull.Value : obj.SpecificationID
            };
            var NumberOfSamplePcs = new SqlParameter
            {
               ParameterName = "NumberOfSamplePcs",
               Value = obj.NumberOfSamplePcs == null ? DBNull.Value : obj.NumberOfSamplePcs
            };
            var QtyPerSample = new SqlParameter
            {
               ParameterName = "QtyPerSample",
               Value = obj.QtyPerSample == null ? DBNull.Value : obj.QtyPerSample
            };
            var ReceivedByID = new SqlParameter
            {
               ParameterName = "ReceivedByID",
               Value = obj.ReceivedByID == null ? DBNull.Value : obj.ReceivedByID
            };
            var ReceivedDateTime = new SqlParameter
            {
               ParameterName = "ReceivedDateTime",
               Value = obj.ReceivedDateTime == null ? DBNull.Value : obj.ReceivedDateTime
            };
            var Note = new SqlParameter
            {
               ParameterName = "Note",
               Value = obj.Note == null ? DBNull.Value : obj.Note
            };
            var isActive = new SqlParameter { ParameterName = "IsActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };

            IEnumerable<SampleSpecificationVM> SamplesSpecificationList = obj.SamplesSpecificationList;

            string child1Sxml = "";
            if (SamplesSpecificationList != null)
            {
               XElement childDataXml1 = new XElement("SamplesSpecificationList", SamplesSpecificationList.Select(x => new XElement("child",
                         new XElement("ID", x.ID),
                         new XElement("SampleID", x.SampleID),
                         new XElement("SpecificationID", x.SpecificationID),
                         new XElement("SpecificationValue", x.Specifications),
                         new XElement("Creator", x.Creator),
                         new XElement("CreationDate", x.CreationDate)

          )));
               child1Sxml = childDataXml1.ToString();
            }

            SqlParameter xmlParm = new SqlParameter("@SamplesSpecificationList", SqlDbType.Xml);
            xmlParm.Value = new SqlXml(System.Xml.XmlReader.Create(new System.IO.StringReader(child1Sxml)));

            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateSampleReceive_SP @ID,@SampleID,@SampleConditionID,@SpecificationID,@NumberOfSamplePcs,@QtyPerSample,@ReceivedByID,@ReceivedDateTime,@Note,@IsActive,@Creator,@SamplesSpecificationList",
                ID, SampleID, SampleConditionID, SpecificationID, NumberOfSamplePcs, QtyPerSample, ReceivedByID, ReceivedDateTime, Note, isActive, Creator, xmlParm).FirstOrDefault();
            if (result.IsSuccess == false)
            {
               result.Code = (int)ProjectCodes.Error;
            }
            else
            {
               result.Code = (int)ProjectCodes.Success;
            }
            var resultFinal = new SaveVM
            {
               ID = result.ID,
               IsSuccess = result.IsSuccess,
               Code = result.Code,
               Message = result.Message,
            };

            return resultFinal;
         }
         catch (Exception ex)
         {
            var result = new SaveVM
            {
               ID = obj.ID,
               Code = (int)ProjectCodes.Error,
               Message = ex.Message,
               IsSuccess = false
            };
            return result;
         }
      }
   }
}
