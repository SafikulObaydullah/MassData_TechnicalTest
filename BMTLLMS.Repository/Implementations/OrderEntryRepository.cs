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
    public class OrderEntryRepository : IOrderEntryRepo
    {
        private readonly RavenDBContext _db;
        public OrderEntryRepository(RavenDBContext db)
        {
            _db = db;
        }
        public OrderEntrySaveVM SaveOrderEntry(OrderEntryVM obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
                var CustomerId = new SqlParameter
                {
                    ParameterName = "CustomerId",
                    Value = obj.CustomerId == 0 ? DBNull.Value : obj.CustomerId
                };
                var ContactName = new SqlParameter
                {
                    ParameterName = "ContactName",
                    Value = obj.ContactName == null ? DBNull.Value : obj.ContactName
                };
            
                var ContactMobile = new SqlParameter
                {
                    ParameterName = "ContactMobile",
                    Value = obj.ContactMobile == null ? DBNull.Value : obj.ContactMobile
                };

                var ContactEmail = new SqlParameter
                {
                    ParameterName = "ContactEmail",
                    Value = obj.ContactEmail == null ? DBNull.Value : obj.ContactEmail
                };

                var ContactAddress = new SqlParameter
                {
                    ParameterName = "ContactAddress",
                    Value = obj.ContactAddress == null ? DBNull.Value : obj.ContactAddress
                };
                var ProjectId = new SqlParameter
                {
                    ParameterName = "ProjectId",
                    Value = obj.ProjectId == 0 ? DBNull.Value : obj.ProjectId
                };
                var ProjectRefNo = new SqlParameter
                {
                    ParameterName = "ProjectRefNo",
                    Value = obj.ProjectRefNo == null ? DBNull.Value : obj.ProjectRefNo
                };
                var OrderDate = new SqlParameter
                {
                    ParameterName = "OrderDate",
                    Value = obj.OrderDate == null ? DBNull.Value : obj.OrderDate
                };
                var CurrencyCode = new SqlParameter
                {
                    ParameterName = "CurrencyCode",
                    Value = obj.CurrencyCode == 0 ? DBNull.Value : obj.CurrencyCode
                };
                var Description = new SqlParameter
                {
                    ParameterName = "Description",
                    Value = obj.Description == null ? DBNull.Value : obj.Description
                };
                var PaymentMode = new SqlParameter
                {
                    ParameterName = "PaymentMode",
                    Value = obj.PaymentMode == null ? DBNull.Value : obj.PaymentMode
                };

                var DiscountAmount = new SqlParameter
                {
                    ParameterName = "DiscountAmount",
                    Value = obj.DiscountAmount == null ? DBNull.Value : obj.DiscountAmount
                };


                //var isActive = new SqlParameter { ParameterName = "IsActive", Value = obj.IsActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };

                IEnumerable<OrderEntryChildVM> OrderEntryChildList = obj.OrderEntryChildList;

                string child1Sxml = "";
                if (OrderEntryChildList != null)
                {
                    XElement childDataXml1 = new XElement("OrderEntryChildList", OrderEntryChildList.Select(x => new XElement("child",
                              new XElement("ID", x.ID),
                              new XElement("ParentID", x.ParentID),
                              new XElement("BatchLot", x.BatchLot),
                              new XElement("Producer", x.Producer),
                              new XElement("TestStandardId", x.TestStandardId),
                              new XElement("TestStandardName", x.TestStandardName),
                              new XElement("SampleCategoryId", x.SampleCategoryId),
                              new XElement("SampleCategoryName", x.SampleCategoryName),
                              new XElement("SampleTypeId", x.SampleTypeId),
                              new XElement("SampleTypeName", x.SampleTypeName),
                              new XElement("TestId", x.TestId),
                              new XElement("TestName", x.TestName),
                              new XElement("QtyPerSample", x.QtyPerSample),
                              new XElement("MeasurementUnitId", x.MeasurementUnitId),
                              new XElement("ReqNumberOfSamplePcs", x.ReqNumberOfSamplePcs),
                              new XElement("SampleID", x.SampleID),
                              //new XElement("RegularPrice", x.RegularPrice),
                              //new XElement("ExpressPrice", x.ExpressPrice),
                              new XElement("Price", x.Price),
                              new XElement("DeliveryDate", x.DeliveryDate) 

               )));
                    child1Sxml = childDataXml1.ToString();
                }
                //var xmlParm = new SqlParameter { ParameterName = "OrderEntryChild", Value = child1Sxml };
                SqlParameter xmlParm = new SqlParameter("@OrderEntryChild", SqlDbType.Xml);
                xmlParm.Value = new SqlXml(System.Xml.XmlReader.Create(new System.IO.StringReader(child1Sxml)));
                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateOrder_SP  @ID,@CustomerId,@ContactName,@ContactMobile,@ContactAddress,@ProjectId,@OrderDate,@CurrencyCode,@Creator, @OrderEntryChild, @ContactEmail ,@Description,@PaymentMode, @DiscountAmount", 
                ID, CustomerId, ContactName, ContactMobile, ContactAddress, ProjectId,  OrderDate, CurrencyCode,  Creator, xmlParm, ContactEmail, Description, PaymentMode, DiscountAmount).FirstOrDefault();

                IEnumerable<OrderDetailVM> resultList = new List<OrderDetailVM>();
                if (result.IsSuccess == false)
                {
                    result.Code = (int)ProjectCodes.Error;
                }
                else
                {
                    result.Code = (int)ProjectCodes.Success;
                    resultList = GetOrderDetail(result.GID);

                }
                var resultFinal = new OrderEntrySaveVM
                {
                    statusCode = (int)ProjectCodes.Success,
                    statusMessage = "Type Message here",
                    data = resultList
                };




                return resultFinal;
            }
            catch (Exception ex)
            {
                var result = new OrderEntrySaveVM
                {
                    statusCode = (int)ProjectCodes.Error,
                    statusMessage = "Type Message here",
                    //statusMessage = StatusMessage.Error.ToString(),
                  
                };
                return result;
            }
        }
        public IEnumerable<OrderDetailVM> GetOrderDetail(string Id)
        {
            //Guid Idd = Guid.NewGuid();

            SqlParameter Parm = new SqlParameter("@GID", SqlDbType.UniqueIdentifier);
            Parm.Value = Id;
            var result = _db.Database.SqlQuery<OrderDetailVM>("GetByIdOrder_SP @GID", Parm).ToList();
            return result;
        }
   }
}
