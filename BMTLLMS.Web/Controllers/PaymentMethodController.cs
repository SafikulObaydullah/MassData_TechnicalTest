using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class PaymentMethodController : Controller
    {
         private readonly IPaymentMethodFacade _paymentMethodFacade;
         public PaymentMethodController(IPaymentMethodFacade paymentMethodFacade)
         { 
            this._paymentMethodFacade = paymentMethodFacade;
         }
         [Authorize]
         public IActionResult PaymentMethod()
         {
            return View();
         }
         [HttpGet]
         [Authorize]
         public JsonResult GetPaymentMethod()
         {
           var response = new PaymentMethodResponseVM();
             try
             {
                  var result = _paymentMethodFacade.GetPaymentMethod(0);
                  response.Data = result;
                  response.StatusCode = "200";
                  response.StatusMessage = "OK";
             }
              catch(Exception ex)
              {
                   /// Log write 
                  response.StatusCode = "500";
                  response.StatusMessage = ex.ToString();
             }
             return Json(response);
         }
         [HttpPost]
         [Authorize]
         public IActionResult PaymentMethodSave(PaymentMethodVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _paymentMethodFacade.SavePaymentMethod(obj);
               return Json(result);
             };
            return Json(obj);  
        }
  
    }

}
