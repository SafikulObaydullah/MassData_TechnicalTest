using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
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
   public class CompanyFacade : ICompanyFacade
   {
      private readonly ICompanyRepo _companyRepository;
        public CompanyFacade(ICompanyRepo companyRepo)
        {
            this._companyRepository = companyRepo;
        }
        public SaveVM SaveCompany(Company obj)
        {
           return _companyRepository.SaveCompany(obj);
        }
      public IEnumerable<Company> GetCompany (Int64 Id)
      {
         return _companyRepository.GetCompany(Id);
      }
   }
}
