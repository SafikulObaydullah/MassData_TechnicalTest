using BMTLLMS.Common;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace BMTLLMS.Web.Controllers
{
    public class OrderEntrySearchController : Controller
    {
        private readonly IOrderEntrySearchFacade _orderEntrySearchFacade;
        public OrderEntrySearchController(IOrderEntrySearchFacade orderEntrySearchFacade)
        {
            _orderEntrySearchFacade = orderEntrySearchFacade;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OrderEntryBySearch(OrderEntrySearchVM obj)
        {
            if (obj.OrderCode == 0)
            {
                obj.OrderCode = 0;
            }
            if (obj.CustomerID == 0)
            {
                obj.CustomerID = 0;
            }
            if (obj.OrderDateFrom == null)
            {
                obj.OrderDateFrom = "";
            }
            if (obj.OrderDateTo == null)
            {
                obj.OrderDateTo = "";
            }
            if (obj.DeliveryDateFrom == null)
            {
                obj.DeliveryDateFrom = "";
            }
            if (obj.DeliveryDateTo == null)
            {
                obj.DeliveryDateTo = "";
            }

            return Json(_orderEntrySearchFacade.OrderEntrySearch(obj));
        }

    }
}
