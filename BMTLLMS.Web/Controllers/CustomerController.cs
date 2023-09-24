

using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class CustomerController : Controller
    {
         private readonly ICustomerFacade _customerFacade;
         public CustomerController(ICustomerFacade customerFacade)
         { 
            this._customerFacade = customerFacade;
         }
         [Authorize]
         public IActionResult Customer()
         {
            return View();
         }
         [Authorize]
         public JsonResult GetCustomer()
         {
           var response = new CustomerResponseVM();
             try
             {
                  var result = _customerFacade.GetCustomer(0);
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
         public IActionResult CustomerSave(CustomerVM obj)
         {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _customerFacade.SaveCustomer(obj);
               return Json(result);
             };
            return Json(obj);  
        }
  
    }

}
