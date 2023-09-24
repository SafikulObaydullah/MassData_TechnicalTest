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
   public class TestStandardWisePriceRepository : ITestStandardWisePriceRepo
   {
      private readonly RavenDBContext _db;
      public TestStandardWisePriceRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SaveTestStandardWisePrice(TestStandardWisePriceVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.TestStandardWisePriceID };
            var TestStandardWiseID = new SqlParameter
            {
               ParameterName = "TestStandardID",
               Value = obj.TestStandardWiseID == null ? DBNull.Value : obj.TestStandardWiseID
            };
            var CurrencyID = new SqlParameter
            {
               ParameterName = "CurrencyID",
               Value = obj.CurrencyWiseID == null ? DBNull.Value : obj.CurrencyWiseID
            };
            var RegularDeliveryDays = new SqlParameter
            {
               ParameterName = "RegularDeliveryDays",
               Value = obj.RegularDeliveryDays == null ? DBNull.Value : obj.RegularDeliveryDays
            };
            var ExpressDeliveryDays = new SqlParameter
            {
               ParameterName = "ExpressDeliveryDays",
               Value = obj.ExpressDeliveryDays == null ? DBNull.Value : obj.ExpressDeliveryDays
            };
            var RegularPrice = new SqlParameter
            {
               ParameterName = "RegularPrice",
               Value = obj.RegularPrice == null ? DBNull.Value : obj.RegularPrice
            };
            var ExpressPrice = new SqlParameter
            {
               ParameterName = "ExpressPrice",
               Value = obj.ExpressPrice == null ? DBNull.Value : obj.ExpressPrice
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

            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateTestStandardWisePrice_SP  @ID,@TestStandardID,@CurrencyID,@RegularDeliveryDays,@ExpressDeliveryDays,@RegularPrice,@ExpressPrice,@EffectiveDateFrom,@EffectiveDateTo,@IsActive,@Creator",
                ID, TestStandardWiseID, CurrencyID, RegularDeliveryDays, ExpressDeliveryDays,RegularPrice, ExpressPrice, EffectiveDateFrom, EffectiveDateTo,isActive, Creator).FirstOrDefault();
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
               ID = obj.TestStandardWisePriceID,
               Code = (int)ProjectCodes.Error,
               Message = ex.Message,
               IsSuccess = false
            };
            return result;
         }
      }
      public IEnumerable<TestStandardWisePriceVM> GetTestStandardWisePrice(long Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<TestStandardWisePriceVM>("GetTestStandardWisePrice_SP @ID", parms).ToList();
         return result;
      }  
   }
}
