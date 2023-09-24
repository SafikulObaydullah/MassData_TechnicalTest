
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
   public class PriceAgreementFacade : IPriceAgreementFacade
   {
      private readonly IPriceAgreementRepo _priceAgreementFacadeRepository;
      public PriceAgreementFacade(IPriceAgreementRepo priceAgreementRepoRepo)
      {
         this._priceAgreementFacadeRepository = priceAgreementRepoRepo;
      }
      public PriceAgreementSaveVM SavePriceAgreementFacade(PriceAgreementVM obj)
      {
         return _priceAgreementFacadeRepository.SavePriceAgreement(obj);
      }
      public IEnumerable<PriceAgreementParentAndChildVM> GetPriceAgreementFacade(long Id)
      {
         return _priceAgreementFacadeRepository.GetPriceAgreement(Id);
      }
   }
}
