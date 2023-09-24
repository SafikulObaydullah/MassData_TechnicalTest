


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
    public class TestController : Controller
    {
         private readonly ITestFacade _testFacade;
         private readonly IAttributeFacade _attributeFacade;
         public TestController(ITestFacade testFacade, IAttributeFacade attributeFacade)
         { 
            this._testFacade = testFacade;
            this._attributeFacade = attributeFacade;
         }
         [Authorize]
         public IActionResult Index()
         {
            return View();
         }
         [Authorize]
         public JsonResult GetTest()
         {
            var response = new TestResponseVM();
            try
            {
               var result = _testFacade.GetTest(0);
               response.Data = result;
               response.StatusCode = "200";
               response.StatusMessage = "OK";
            }
            catch (Exception ex)
            {
               /// Log write 
               response.StatusCode = "500";
               response.StatusMessage = ex.ToString();
            }
            return Json(response);
         }
      [HttpPost]
         [Authorize]
        public IActionResult TestSave(TestVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _testFacade.SaveTest(obj);
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
               result.attribute = _attributeFacade.GetAttribute(0,1).Where(x => x.IsActive == true).ToList();

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
