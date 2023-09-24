




using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class ProjectController : Controller
    {
         private readonly IProjectFacade _projectFacade;
         public ProjectController(IProjectFacade projectFacade)
         { 
            this._projectFacade = projectFacade;
         }
         [Authorize]
         public IActionResult Project()
         {
            return View();
         }
        [Authorize]
        [HttpGet]
         public JsonResult GetProject()
         {
           var response = new ProjectResponseVM();
             try
             {
                  var result = _projectFacade.GetProject(0);
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
         [Authorize]
         [HttpPost]
         public IActionResult ProjectSave(ProjectVM obj)
         {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _projectFacade.SaveProject(obj);
               return Json(result);
             };
            return Json(obj);  
         }
  
    }

}
