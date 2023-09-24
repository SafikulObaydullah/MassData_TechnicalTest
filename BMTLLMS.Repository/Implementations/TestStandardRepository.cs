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
   public class TestStandardRepository : ITestStandardRepo
   {
      private readonly RavenDBContext _db;
      public TestStandardRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SaveTestStandard(TestStandardVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.TestStandardID };
            var Name = new SqlParameter
            {
               ParameterName = "Name",
               Value = obj.TestStandardName == null ? DBNull.Value : obj.TestStandardName
            };
            var TestNameID = new SqlParameter
            {
               ParameterName = "TestNameID",
               Value = obj.TestNameID == null ? DBNull.Value : obj.TestNameID
            };
            
            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateTestStandard_SP  @ID,@Name,@TestNameID,@IsActive,@Creator",
                ID, Name,TestNameID,isActive,Creator).FirstOrDefault();
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
               ID = obj.TestStandardID,
               Code = (int)ProjectCodes.Error,
               Message = ex.Message,
               IsSuccess = false
            };
            return result;
         }
      }
      public IEnumerable<TestStandardVM> GetTestStandard(Int64 Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<TestStandardVM>("GetTestStandard_SP @ID", parms).ToList();
         return result;
      } 
   }
}
