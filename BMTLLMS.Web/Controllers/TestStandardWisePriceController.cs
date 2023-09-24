using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class TestStandardWisePriceController : Controller
    {
         private readonly ITestStandardWisePriceFacade _testStandardWisePriceFacade;
         public TestStandardWisePriceController(ITestStandardWisePriceFacade testStandardFacade)
         { 
            _testStandardWisePriceFacade = testStandardFacade;
         }
         [Authorize]
         public IActionResult Index()
         {
            return View();
         }
         [Authorize]
         public JsonResult GetTestStandardWisePrice()
         {
           var response = new TestStandardWisePriceResponseVM();
             try
             {
                  var result = _testStandardWisePriceFacade.GetTestStandardWisePrice(0);
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
         public IActionResult TestStandardWisePriceSave(TestStandardWisePriceVM obj)
         {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _testStandardWisePriceFacade.SaveTestStandardWisePrice(obj);
               return Json(result);
             };
            return Json(obj);  
         }
  
    }

}
