
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Domain.ViewModel.Response.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Contracts
{
   public interface ITestFacade
   {
      SaveVM SaveTest(TestVM obj);
      IEnumerable<TestVM> GetTest(Int64 Id);
      Task<TestEntryDashboardResponse> GetTestEntryDashboardFacade(int UserId);
        Task<IEnumerable<UserWiseTestAssignListResponse>> GetUserWiseTestAssignFacade(int UserId, int status);
   }
}
