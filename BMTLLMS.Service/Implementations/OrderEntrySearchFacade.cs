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
    public class OrderEntrySearchFacade : IOrderEntrySearchFacade
    {
        private readonly IOrderEntrySearchRepository _orderEntrySearchRepository;
        public OrderEntrySearchFacade(IOrderEntrySearchRepository orderEntrySearchRepo)
        {
            this._orderEntrySearchRepository = orderEntrySearchRepo;
        }
        public IEnumerable<OrderEntrySearchListVM> OrderEntrySearch(OrderEntrySearchVM obj)
        {
            return _orderEntrySearchRepository.OrderEntrySearch(obj);
        }

    }
}
