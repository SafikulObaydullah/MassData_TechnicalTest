using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class AttributeController : Controller
    {
         private readonly IAttributeFacade _attributeFacade;
         public AttributeController(IAttributeFacade attributeFacade)
         { 
            this._attributeFacade = attributeFacade;
         }
         [Authorize]
         public IActionResult Attribute()
         {
            return View();
         }
         [Authorize]
         public JsonResult GetAttribute()
         {
           var response = new AttributeResponseVM();
             try
             {
                  var result = _attributeFacade.GetAttribute(0,0);
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
        public IActionResult AttributeSave(AttributeVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _attributeFacade.SaveAttribute(obj);
               return Json(result);
             };
            return Json(obj);  
        }
  
    }

}
