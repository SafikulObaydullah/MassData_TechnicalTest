using BMTLLMS.Common;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;

namespace BMTLLMS.Web.Controllers
{
    public class SampleReceiveController : Controller
    {
      private readonly IOrderEntryFacade _orderentryFacade;
      private readonly ICustomerFacade _customerFacade;
      private readonly IProjectFacade _projectFacade;
      private readonly ISampleReceiveFacade _sampleReceiveFacade;
      private readonly ISpecificationHeadFacade _specificationHeadFacade; 

         public SampleReceiveController(IOrderEntryFacade orderEntryFacade, 
            ICustomerFacade customerFacade,IProjectFacade projectFacade,ISampleReceiveFacade sampleReceiveFacade, ISpecificationHeadFacade specificationHeadFacade)
         {
              _orderentryFacade = orderEntryFacade;   
             _customerFacade = customerFacade;  
             _projectFacade = projectFacade;
             _sampleReceiveFacade = sampleReceiveFacade;
             _specificationHeadFacade = specificationHeadFacade;
         }
         [Authorize]
         public IActionResult Index()
         {
            return View();
         }
         [HttpPost]
         [Authorize]
         public IActionResult SaveSampleReceive(SampleReceiveVM obj)
         {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            obj.ReceivedByID = Convert.ToInt64(user[1].Value);
            obj.ReceivedDateTime = DateTime.Now; 
            if (ModelState.IsValid)
            {
               var result = _sampleReceiveFacade.SaveSampleReceive(obj);
               return Json(result);
            };
            return Json(obj);
         }
         [Authorize]
         [HttpGet]
         public JsonResult GetInitialData()
         {
         SampleReceiveSearchListVM obj = new SampleReceiveSearchListVM();
            obj.OrderRefNo = 0;
            obj.OrderDateFrom = "";
            obj.OrderDateTo = "";
            obj.StatusID = 0;
            obj.DeliveryDateFrom = "";
            obj.DeliveryDateTo = "";
            dynamic result = new ExpandoObject();
            try
            {
               result.samplePhysicalCondtion = _specificationHeadFacade.GetSamplePhysicalCondition();
               result.orderList = _sampleReceiveFacade.GetOrderDetailList(obj).ToList();
               result.specificationHead = _specificationHeadFacade.GetSpecificationHead().Where(x => x.IsActive == true).ToList();
               result.customer = _customerFacade.GetCustomer(0).Where(x => x.IsActive == true).ToList();
               result.statusMessage = StatusMessage.Success;
            }
            catch (Exception ex)
            {
               result.StatusCode = ProjectCodes.Error;
               result.StatusMessage = StatusMessage.Error;
            }
            return Json(result);
         }
         [Authorize]
         [HttpGet]
         public IActionResult SearchResult(SampleReceiveSearchListVM obj)
         {
            if (obj.OrderRefNo == null)
            {
               obj.OrderRefNo = 0;
            }
            if (obj.OrderDateFrom == null)
            {
               obj.OrderDateFrom = "";
            }
            if (obj.OrderDateTo == null)
            {
               obj.OrderDateTo = "";
            }
            if (obj.CustomerID == null)
            {
               obj.CustomerID = 0;
            }
            if (obj.StatusID == null)
            {
               obj.StatusID = 0;
            }
            if (obj.DeliveryDateFrom == null)
            {
               obj.DeliveryDateFrom = "";
            }
            if (obj.DeliveryDateTo == null)
            {
               obj.DeliveryDateTo = "";
            }
            return Json(_sampleReceiveFacade.GetOrderDetailList(obj));
         }
   } 
}
