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
    public class SpecificationHeadFacade : ISpecificationHeadFacade
    {
        private readonly ISpecificationHeadRepository _specificationHeadRepository;
        public SpecificationHeadFacade(ISpecificationHeadRepository specificationHeadRepo)
        {
            this._specificationHeadRepository = specificationHeadRepo;
        }
        public SaveVM SaveSpecificationHead(SpecificationHeadVM obj)
        {
            return _specificationHeadRepository.SaveSpecificationHead(obj);
        }
        public IEnumerable<SpecificationHeadVM> GetSpecificationHead()
        {
            return _specificationHeadRepository.GetSpecificationHead();
        }
        public IEnumerable<SamplePhysicalCondition> GetSamplePhysicalCondition()
        {
           return _specificationHeadRepository.GetSamplePhysicalCondition();
        } 
   }
}
