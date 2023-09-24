



using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Repository.Contracts;
using EntityFrameworkCore.RawSQLExtensions.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Implementations
{
   public class CustomerRepository : ICustomerRepo
   {
      private readonly RavenDBContext _db;
      public CustomerRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SaveCustomer(CustomerVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var Name = new SqlParameter
            {
               ParameterName = "Name",
               Value = obj.Name == null ? DBNull.Value : obj.Name
            };
            var ContactPersonName = new SqlParameter
            {
               ParameterName = "ContactPersonName",
               Value = obj.ContactPersonName == null ? DBNull.Value : obj.ContactPersonName
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
            var ContactPhone = new SqlParameter
            {
               ParameterName = "ContactPhone",
               Value = obj.ContactPhone == null ? DBNull.Value : obj.ContactPhone
            };
            
            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateCustomer_SP  @ID,@Name,@ContactPersonName,@ContactEmail,@ContactAddress,@ContactPhone,@IsActive,@Creator",
                ID, Name, ContactPersonName, ContactEmail, ContactAddress, ContactPhone,isActive, Creator).FirstOrDefault();
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
      public IEnumerable<CustomerVM> GetCustomer (Int64 Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<CustomerVM>("GetCustomer_SP @ID", parms).ToList();
         return result;
      }

   }
}
