


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
    public class UserController : Controller
    {
         private readonly IUserFacade _userFacade;
         private readonly IAttributeFacade _attributeFacade;
         private readonly ISectionFacade _sectionFacade;
         public UserController(IUserFacade userFacade,IAttributeFacade attributeFacade,ISectionFacade sectionFacade)
         { 
            _userFacade = userFacade;
            _attributeFacade = attributeFacade;
            _sectionFacade = sectionFacade;
         }
         [Authorize]
         public IActionResult Index()
         {
            return View();
         }
         [HttpPost]
         [Authorize]
         public IActionResult UserSave(UserVM obj)
         {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _userFacade.SaveUser(obj);
               return Json(result);
             };
            return Json(obj);  
        }
      [HttpPost]
      [Authorize]
      public IActionResult ChangePassword(UserVM obj)
      {
         var user = User.Claims.ToList();
         obj.Creator = Convert.ToInt64(user[1].Value);
         if (ModelState.IsValid)
         {
            var result = _userFacade.ChangePassword(obj);
            return Json(result);
         };
         return Json(obj);
      }
      [Authorize]
         [HttpGet]
         public JsonResult GetInitialData()
         {
            dynamic result = new ExpandoObject();
            try
            {
               result.attributes = _attributeFacade.GetAttribute(0,5).Where(x => x.IsActive == true).ToList();
               result.sections = _sectionFacade.GetSection().Where(x => x.IsActive == true).ToList();
               result.users =  _userFacade.GetUser(0);
            result.statusMessage = StatusMessage.Success;
            }
            catch (Exception ex)
            {
               result.StatusCode = ProjectCodes.Error;
               result.StatusMessage = StatusMessage.Error;
            }
            return Json(result);
         }
   }

}
