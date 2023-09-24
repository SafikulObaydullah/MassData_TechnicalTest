
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
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
    public class TestSampleInfoFacade : ITestSampleInfoFacade
    {
        private readonly ITestSampleInfoRepository _testSampleInfoFacadeRepository;
        public TestSampleInfoFacade(ITestSampleInfoRepository testSampleInfoRepoRepo)
        {
            this._testSampleInfoFacadeRepository = testSampleInfoRepoRepo;
        }

        public IEnumerable<TestSampleInfoVM> GetTestSampleInfoFacade(Int64 CustomerId, Int64 CurrencyCode)
        {
            return _testSampleInfoFacadeRepository.GetTestSampleInfo(CustomerId,CurrencyCode);
        }
    }
}
