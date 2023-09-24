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
   public class PriceAgreementSearchFacade : IPriceAgreementSearchFacade
   {
      private readonly IPriceAgreementSearchRepo _priceAgreementSearchRepository;
      public PriceAgreementSearchFacade(IPriceAgreementSearchRepo priceAgreementSearchRepo)
      {
         this._priceAgreementSearchRepository = priceAgreementSearchRepo;
      } 
      public IEnumerable<PriceAgreementSearchListVM> PriceAgreementSearch(PriceAgreementSearchVM obj)
      {
         return _priceAgreementSearchRepository.PriceAgreementSearch(obj);
      }
      public IEnumerable<PriceAgreementParentAndChildVM> PriceAgreementParentChildDetails(long Id)
      {
         return _priceAgreementSearchRepository.GetPriceAgreementChildDetails(Id);
      }
       
   }
}
