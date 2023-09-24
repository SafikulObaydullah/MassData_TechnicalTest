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
    public class TestStandardVsMachineFacade : ITestStandardVsMachineFacade
    {
        private readonly ITestStandardVsMachineRepository _testStandardVsMachineRepository;
        public TestStandardVsMachineFacade(ITestStandardVsMachineRepository testStandardVsMachineRepo)
        {
            this._testStandardVsMachineRepository = testStandardVsMachineRepo;
        }
        public SaveVM SaveTestStandardVsMachine(TestStandardVsMachineVM obj)
        {
            return _testStandardVsMachineRepository.SaveTestStandardVsMachine(obj);
        }
        public IEnumerable<TestStandardVsMachineVM> GetTestStandardVsMachine()
        {
            return _testStandardVsMachineRepository.GetTestStandardVsMachine();
        }
    }
}
