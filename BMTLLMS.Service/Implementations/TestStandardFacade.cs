
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
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
   public class TestStandardFacade : ITestStandardFacade
   {
      private readonly ITestStandardRepo _testStandardRepository;
      public TestStandardFacade(ITestStandardRepo testStandardRepo)
      {
         this._testStandardRepository = testStandardRepo;
      }
      public SaveVM SaveTestStandard(TestStandardVM obj)
      {
         return _testStandardRepository.SaveTestStandard(obj);
      }
      public IEnumerable<TestStandardVM> GetTestStandard(Int64 Id)
      {
         return _testStandardRepository.GetTestStandard(Id);
      } 
   }
}
