using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Contracts
{
   public interface ITestRepo
   {
      SaveVM SaveTest(TestVM obj);
      IEnumerable<TestVM> GetTest(Int64 Id);
      Task<TestEntryDashboardResponse> GetTestDataEntryDashboardByUserIdAsync(int UserId);
        Task<IEnumerable<UserWiseTestAssignListResponse>> GetuserWiseTestAssignListAsync(int UserId, int status);
   }
}
