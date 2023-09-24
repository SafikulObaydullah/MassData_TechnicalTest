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
    public class SampleCategoryFacade : ISampleCategoryFacade
    {
        private readonly ISampleCategoryRepository _sampleCategoryRepository;
        public SampleCategoryFacade(ISampleCategoryRepository sampleCategoryRepo)
        {
            this._sampleCategoryRepository = sampleCategoryRepo;
        }
        public SaveVM SaveSampleCategory(SampleCategoryVM obj)
        {
            return _sampleCategoryRepository.SaveSampleCategory(obj);
        }
        public IEnumerable<SampleCategoryVM> GetSampleCategory()
        {
            return _sampleCategoryRepository.Get();
        }
    }
}
