



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
   public class PaymentMethodFacade : IPaymentMethodFacade
   {
      private readonly IPaymentMethodRepo _paymentMethodRepository;
      public PaymentMethodFacade(IPaymentMethodRepo paymentMethodRepo)
      {
         this._paymentMethodRepository = paymentMethodRepo;
      }
      public SaveVM SavePaymentMethod(PaymentMethodVM obj)
      {
           return _paymentMethodRepository.SavePaymentMethod(obj);
      }
      public IEnumerable<PaymentMethodVM> GetPaymentMethod(long Id)
      {
         return _paymentMethodRepository.GetPaymentMethod(Id);
      }
   }
}
