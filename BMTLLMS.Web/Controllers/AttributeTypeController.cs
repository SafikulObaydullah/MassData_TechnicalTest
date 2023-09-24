using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class AttributeTypeController : Controller
    {
         private readonly IAttributeTypeFacade _attributeTypeFacade;
         public AttributeTypeController(IAttributeTypeFacade _attributeTypeFacade)
         { 
            this._attributeTypeFacade = _attributeTypeFacade;
         }
         [Authorize]
         public IActionResult Index()
         {
            return View();
         }
         [Authorize]
         public JsonResult GetAttributeType()
         {
           var response = new AttributeTypeResponseVM();
             try
             {
                  var result = _attributeTypeFacade.GetAttributeType(0);
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
        public IActionResult AttributeTypeSave(AttributTypeVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _attributeTypeFacade.SaveAttributeType(obj);
               return Json(result);
             };
            return Json(obj);  
        }
  
    }

}
