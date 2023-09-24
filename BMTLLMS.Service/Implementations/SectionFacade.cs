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
    public class SectionFacade : ISectionFacade
    {
        private readonly ISectionRepository _sectionRepository;
        public SectionFacade(ISectionRepository sectionRepo)
        {
            this._sectionRepository = sectionRepo;
        }
        public SaveVM SaveSection(SectionVM obj)
        {
            return _sectionRepository.SaveSection(obj);
        }
        public IEnumerable<SectionVM> GetSection()
        {
            return _sectionRepository.GetSection();
        }
    }
}
