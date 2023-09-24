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
   public class PriceAgreementChildFacade : IPriceAgreementChildFacade
   {
      private readonly IPriceAgreementChildRepo _priceAgreementChildFacadeRepository;
      public PriceAgreementChildFacade(IPriceAgreementChildRepo priceAgreementChildRepoRepo)
      {
         this._priceAgreementChildFacadeRepository = priceAgreementChildRepoRepo;
      }
      public SaveVM SavePriceAgreementChildFacade(PriceAgreementChildVM obj)
      {
         return _priceAgreementChildFacadeRepository.SavePriceAgreementChild(obj);
      }
      public IEnumerable<PriceAgreementChildVM> GetPriceAgreementChildFacade(long Id)
      {
         return _priceAgreementChildFacadeRepository.GetPriceAgreementChild(Id);
      }
   }
}
