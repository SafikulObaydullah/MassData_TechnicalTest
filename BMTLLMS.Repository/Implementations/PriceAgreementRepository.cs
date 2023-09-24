using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Repository.Contracts;
using EntityFrameworkCore.RawSQLExtensions.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.SqlTypes;
using BMTLLMS.Domain.ViewModel.Response;

namespace BMTLLMS.Repository.Implementations
{
   public class PriceAgreementRepository : IPriceAgreementRepo
   {
      private readonly RavenDBContext _db;
      public PriceAgreementRepository(RavenDBContext db)
      {
         _db = db;
      }
      public PriceAgreementSaveVM SavePriceAgreement(PriceAgreementVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var CustomerID = new SqlParameter
            {
               ParameterName = "CustomerID",
               Value = obj.CustomerID == null ? DBNull.Value : obj.CustomerID
            };
            var AgreementDate = new SqlParameter
            {
               ParameterName = "AgreementDate",
               Value = obj.AgreementDate == null ? DBNull.Value : obj.AgreementDate
            };
            var EffectiveDateFrom = new SqlParameter
            {
               ParameterName = "EffectiveDateFrom",
               Value = obj.EffectiveDateFrom == null ? DBNull.Value : obj.EffectiveDateFrom
            };
            var EffectiveDateTo = new SqlParameter
            {
               ParameterName = "EffectiveDateTo",
               Value = obj.EffectiveDateTo == null ? DBNull.Value : obj.EffectiveDateTo
            };
            var Description = new SqlParameter
            {
               ParameterName = "Description",
               Value = obj.Description == null ? DBNull.Value : obj.Description
            }; 
            var Signee_id = new SqlParameter
            {
               ParameterName = "Signee_id",
               Value = obj.Signee_id == null ? DBNull.Value : obj.Signee_id
            };
            var CustomerSideSigneeName = new SqlParameter
            {
               ParameterName = "CustomerSideSigneeName",
               Value = obj.CustomerSideSigneeName == null ? DBNull.Value : obj.CustomerSideSigneeName
            };
            var CustomerSideSigneeDesignation = new SqlParameter
            {
               ParameterName = "CustomerSideSigneeDesignation",
               Value = obj.CustomerSideSigneeDesignation == null ? DBNull.Value : obj.CustomerSideSigneeDesignation
            };
            var isActive = new SqlParameter { ParameterName = "IsActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            IEnumerable<PriceAgreementChildVM> PriceAgreementChildList = obj.PriceAgreementChildList;
            
            string child1Sxml = "";
            if (PriceAgreementChildList != null)
            {
               XElement childDataXml1 = new XElement("PriceAgreementChildList", PriceAgreementChildList.Select(x => new XElement("child",
                         new XElement("ID", x.ChildID),
                         new XElement("ParentID", x.ParentID),
                         new XElement("TestStandardID", x.TestStandardID),
                         new XElement("SampleTypeID", x.SampleTypeID),
                         new XElement("RegularPrice", x.RegularPrice),
                         new XElement("ExpressPrice", x.ExpressPrice),
                         new XElement("CurrencyID", x.CurrencyID),
                         new XElement("Note", x.Note),
                         new XElement("IsActive", x.IsActive),
                         new XElement("Creator", x.Creator),
                         new XElement("CreationDate", x.CreationDate)
                         
          )));
               child1Sxml = childDataXml1.ToString(); 
            }  

            SqlParameter xmlParm = new SqlParameter("@PriceAgreementChild", SqlDbType.Xml);
            xmlParm.Value = new SqlXml(System.Xml.XmlReader.Create(new System.IO.StringReader(child1Sxml)));
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdatePriceAgreement_SP  @ID,@CustomerID,@AgreementDate,@EffectiveDateFrom,@EffectiveDateTo,@Description,@Signee_id,@CustomerSideSigneeName,@CustomerSideSigneeDesignation,@IsActive,@Creator,@PriceAgreementChild",
            ID, CustomerID, AgreementDate, EffectiveDateFrom, EffectiveDateTo, Description, Signee_id, CustomerSideSigneeName, CustomerSideSigneeDesignation, isActive, Creator, xmlParm).FirstOrDefault();

            var parentID = new SqlParameter { ParameterName = "ID", Value = result.ID };
            var priceAgreementList = _db.Database.SqlQuery<PriceAgreementParentAndChildVM>("GetPriceAgreementParentAndChild_SP @ID", parentID).ToList();
            IEnumerable<PriceAgreementParentAndChildVM> resultList = new List<PriceAgreementParentAndChildVM>();
            if (result.IsSuccess == false)
            {
               result.Code = (int)ProjectCodes.Error;
            }
            else
            {
               result.Code = (int)ProjectCodes.Success;
               resultList = GetPriceAgreement(result.ID);  
            }
            var resultFinal = new PriceAgreementSaveVM
            {
               statusCode = (int)ProjectCodes.Success,
               statusMessage = "Type Message here",
               data = resultList,
            };

            return resultFinal;
         }
         //catch (Exception ex)
         //{
         //   var result = new SaveVM
         //   {
         //      ID = obj.ID,
         //      Code = (int)ProjectCodes.Error,
         //      Message = ex.Message,
         //      IsSuccess = false
         //   };
         //   return result;
         //}
         catch (Exception ex)
         {
            var result = new PriceAgreementSaveVM
            {
               statusCode = (int)ProjectCodes.Error,
               statusMessage = "Type Message here",
               //statusMessage = StatusMessage.Error.ToString(),

            };
            return result;
         }
      }
      public IEnumerable<PriceAgreementParentAndChildVM> GetPriceAgreement(long Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<PriceAgreementParentAndChildVM>("GetPriceAgreementParentAndChild_SP @ID", parms).ToList();
         return result;
      }
   }
}
