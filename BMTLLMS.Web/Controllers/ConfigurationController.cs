using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class ConfigurationController : Controller
    {
         private readonly ICompanyFacade _companyFacade;
         public ConfigurationController(ICompanyFacade companyFacade)
         { 
            this._companyFacade = companyFacade;
         }
         public IActionResult Index()
         {
            return View();
         }
         [Authorize]
         public IActionResult Company()
         {
            return View();
         }
         [Authorize]
         public JsonResult GetCompanyData()
         {
           var response = new CompanyResponseVM();
             try
             {
                  var result = _companyFacade.GetCompany(0);
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
         public IActionResult CompanyDataSave(Company obj)
         {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _companyFacade.SaveCompany(obj);
               return Json(result);
             };
            return Json(obj);  
        }
  
    }

}
