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
   public class TestStandardWisePriceFacade : ITestStandardWisePriceFacade
   {
      private readonly ITestStandardWisePriceRepo _teststandardwisePriceRepository;
      public TestStandardWisePriceFacade(ITestStandardWisePriceRepo teststandardwisePriceRepository)
      {
         this._teststandardwisePriceRepository = teststandardwisePriceRepository;
      }
      public SaveVM SaveTestStandardWisePrice(TestStandardWisePriceVM obj)
      {
         return _teststandardwisePriceRepository.SaveTestStandardWisePrice(obj);
      }
      public IEnumerable<TestStandardWisePriceVM> GetTestStandardWisePrice(long Id)
      {
         return _teststandardwisePriceRepository.GetTestStandardWisePrice(Id);
      } 
   }
}
