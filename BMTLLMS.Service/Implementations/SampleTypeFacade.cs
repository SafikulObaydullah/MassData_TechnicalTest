using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Implementations
{
    public class SampleTypeFacade : ISampleTypeFacade
    {
        private readonly ISampleTypeRepository _sampletypeRepository;
        public SampleTypeFacade(ISampleTypeRepository sampletypeRepository)
        {
            _sampletypeRepository = sampletypeRepository;

        }

        public IEnumerable<SampleType> Get()
        {
            return _sampletypeRepository.Get();

        }

        public SaveVM SaveSampleType(SampleType sampletype)
        {
            return _sampletypeRepository.SaveSampleType(sampletype);
        }
    }
}
