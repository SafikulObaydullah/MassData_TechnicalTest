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
    public class SampleTypeVsTestStandardFacade : ISampleTypeVsTestStandardFacade
    {
        private readonly ISampleTypeVsTestStandardRepository _sampleTypeVsTestStandardRepository;
        public SampleTypeVsTestStandardFacade(ISampleTypeVsTestStandardRepository sampleTypeVsTestStandardRepo)
        {
            this._sampleTypeVsTestStandardRepository = sampleTypeVsTestStandardRepo;
        }
        public SaveVM SaveSampleTypeVsTestStandard(SampleTypeVsTestStandardVM obj)
        {
            return _sampleTypeVsTestStandardRepository.SaveSampleTypeVsTestStandard(obj);
        }
        public IEnumerable<SampleTypeVsTestStandardVM> GetSampleTypeVsTestStandard()
        {
            return _sampleTypeVsTestStandardRepository.GetSampleTypeVsTestStandard();
        }
    }
}
