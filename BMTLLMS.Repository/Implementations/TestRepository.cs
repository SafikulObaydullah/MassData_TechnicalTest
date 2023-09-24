


using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response.API;
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
   public class TestRepository : ITestRepo
   {
      private readonly RavenDBContext _db;
      public TestRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SaveTest(TestVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var TestName = new SqlParameter
            {
               ParameterName = "Name",
               Value = obj.TestName == null ? DBNull.Value : obj.TestName
            };
            var TestGroupAttributeID = new SqlParameter
            {
               ParameterName = "TestGroupAttributeID",
               Value = obj.TestGroupAttributeID == null ? DBNull.Value : obj.TestGroupAttributeID
            };
            
            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateTest_Name_SP  @ID,@Name,@TestGroupAttributeID,@IsActive,@Creator",
                ID, TestName, TestGroupAttributeID, isActive, Creator).FirstOrDefault();
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
      public IEnumerable<TestVM> GetTest(Int64 Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<TestVM>("GetTestName_SP @ID", parms).ToList();
         return result;
      } 
      public async Task<TestEntryDashboardResponse> GetTestDataEntryDashboardByUserIdAsync( int UserId)
        {
            string SP = "Mob_TestDataEntryUserDashboard_SP '" + UserId + "'";
            var result = _db.Database.SqlQuery<TestEntryDashboardResponse>(SP).FirstOrDefault();
            return await Task.FromResult( result);
        }
        public async Task<IEnumerable<UserWiseTestAssignListResponse>> GetuserWiseTestAssignListAsync(int UserId, int status)
        {
            string SP = "Mob_TestDataEntryListByUser_SP '" + UserId + "', '"+status+"'";
            var result = _db.Database.SqlQuery<UserWiseTestAssignListResponse>(SP).ToListAsync();
            return await result;
        }
    }
}
