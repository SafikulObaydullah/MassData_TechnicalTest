
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
   public class CustomerFacade : ICustomerFacade
   {
      private readonly ICustomerRepo _customerRepo;
        public CustomerFacade(ICustomerRepo customerRepo)
        {
            this._customerRepo = customerRepo;
        }
        public SaveVM SaveCustomer(CustomerVM obj)
        {
           return _customerRepo.SaveCustomer(obj);
        }
      public IEnumerable<CustomerVM> GetCustomer(Int64 Id)
      {
         return _customerRepo.GetCustomer(Id);
      }
   }
}
