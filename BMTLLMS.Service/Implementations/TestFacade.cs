using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Domain.ViewModel.Response.API;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Repository.Implementations;
using BMTLLMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Implementations
{
   public class TestFacade : ITestFacade
   {
      private readonly ITestRepo _testRepository;
      public TestFacade(ITestRepo testRepo)
      {
         this._testRepository = testRepo;
      }
      public SaveVM SaveTest(TestVM obj)
      {
         return _testRepository.SaveTest(obj);
      }
      public IEnumerable<TestVM> GetTest(Int64 Id)
      {
         return _testRepository.GetTest(Id);
      }
      public async Task<TestEntryDashboardResponse> GetTestEntryDashboardFacade(int UserId)
        {
            return await _testRepository.GetTestDataEntryDashboardByUserIdAsync(UserId);
        }
        public async Task<IEnumerable<UserWiseTestAssignListResponse>> GetUserWiseTestAssignFacade(int UserId,int status)
        {
            return await _testRepository.GetuserWiseTestAssignListAsync(UserId,status);
        }
    }
}
