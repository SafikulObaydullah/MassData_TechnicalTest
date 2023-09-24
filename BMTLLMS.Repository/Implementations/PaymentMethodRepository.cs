
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
   public class PaymentMethodRepository : IPaymentMethodRepo
   {
      private readonly RavenDBContext _db;
      public PaymentMethodRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SavePaymentMethod(PaymentMethodVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var Name = new SqlParameter
            {
               ParameterName = "Name",
               Value = obj.Name == null ? DBNull.Value : obj.Name
            };
            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdatePaymentMethod_SP  @ID,@Name,@IsActive,@Creator",
                ID, Name,isActive, Creator).FirstOrDefault();
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
      public IEnumerable<PaymentMethodVM> GetPaymentMethod(Int64 Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<PaymentMethodVM>("GetPyamentMethod_SP @ID", parms).ToList();
         return result;
      }
   }
}
