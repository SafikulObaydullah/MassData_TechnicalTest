
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
    public class OrderEntryFacade : IOrderEntryFacade
    {
        private readonly IOrderEntryRepo _orderEntryFacadeRepository;
        public OrderEntryFacade(IOrderEntryRepo orderEntryRepoRepo)
        {
            this._orderEntryFacadeRepository = orderEntryRepoRepo;
        }
        public OrderEntrySaveVM SaveOrderEntryFacade(OrderEntryVM obj)
        {
            return _orderEntryFacadeRepository.SaveOrderEntry(obj);
        }
        public IEnumerable<OrderDetailVM> GetOrderDetail(string Id)
        {
            return _orderEntryFacadeRepository.GetOrderDetail(Id);
        } 
   }
}
