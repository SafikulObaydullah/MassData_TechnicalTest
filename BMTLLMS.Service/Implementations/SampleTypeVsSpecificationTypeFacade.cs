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
    public class SampleTypeVsSpecificationTypeFacade : ISampleTypeVsSpecificationTypeFacade
    {
        private readonly ISampleTypeVsSpecificationTypeRepository _sampleTypeVsSpecificationTypeRepository;
        public SampleTypeVsSpecificationTypeFacade(ISampleTypeVsSpecificationTypeRepository sampleTypeVsSpecificationTypeRepo)
        {
            this._sampleTypeVsSpecificationTypeRepository = sampleTypeVsSpecificationTypeRepo;
        }
        public SaveVM SaveSampleTypeVsSpecificationType(SampleTypeVsSpecificationTypeVM obj)
        {
            return _sampleTypeVsSpecificationTypeRepository.SaveSampleTypeVsSpecificationType(obj);
        }
        public IEnumerable<SampleTypeVsSpecificationTypeVM> GetSampleTypeVsSpecificationType()
        {
            return _sampleTypeVsSpecificationTypeRepository.GetSampleTypeVsSpecificationType();
        }
    }
}
