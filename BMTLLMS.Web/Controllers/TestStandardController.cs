
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class TestStandardController : Controller
    {
         private readonly ITestStandardFacade _testStandardFacade;
         public TestStandardController(ITestStandardFacade testStandardFacade)
         { 
            this._testStandardFacade = testStandardFacade;
         }
         [Authorize]
         public IActionResult Index()
         {
            return View();
         }
         [Authorize]
         public JsonResult GetTestStandard()
         {
           var response = new TestStandardResponseVM();
             try
             {
                  var result = _testStandardFacade.GetTestStandard(0);
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
        public IActionResult TestStandardSave(TestStandardVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _testStandardFacade.SaveTestStandard(obj);
               return Json(result);
             };
            return Json(obj);  
        }
    }

}
