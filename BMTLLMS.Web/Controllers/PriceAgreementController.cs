using BMTLLMS.Common;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Service.Contracts;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;
using BMTLLMS.Service.Implementations;

namespace BMTLLMS.Web.Controllers
{
    public class PriceAgreementController : Controller
    {

        private readonly IPriceAgreementFacade _priceAgreementFacade;
        private readonly IPriceAgreementSearchFacade _priceAgreementsearchFacade;
        private readonly ICustomerFacade _customerFacade;
        private readonly ITestStandardFacade _testStandardFacade;
        private readonly ICurrencyFacade _currencyFacade;
      public PriceAgreementController(IPriceAgreementFacade priceAgreementFacade,
                       ICustomerFacade customerFacade,ITestStandardFacade testStandardFacade,
                       ICurrencyFacade currencyFacade, IPriceAgreementSearchFacade searchFacade)
        {
             _priceAgreementFacade = priceAgreementFacade;
             _customerFacade = customerFacade;
             _testStandardFacade=testStandardFacade;
             _currencyFacade = currencyFacade;
             _priceAgreementsearchFacade = searchFacade;
        } 
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult PriceAgreementSave(PriceAgreementVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
               var result = _priceAgreementFacade.SavePriceAgreementFacade(obj);
               return Json(result);
            }
            return View(); 
        }
        [Authorize]
        [HttpGet]
        public JsonResult GetPriceAgreement()
        {
            return Json(_priceAgreementFacade.GetPriceAgreementFacade(0));
        }
      [Authorize]
      [HttpGet]
      public JsonResult GetInitialData()
      {
         PriceAgreementSearchVM obj = new PriceAgreementSearchVM();
         obj.CustomerID = 0;
         obj.AgreementDate = "";
         obj.AgreementToDate = "";
         obj.EffectiveDateFrom = "";
         obj.EffectiveDateTo = "";
         dynamic result = new ExpandoObject();
         try
         {
            result.searchList = _priceAgreementsearchFacade.PriceAgreementSearch(obj);
            result.customer = _customerFacade.GetCustomer(0).Where(x => x.IsActive == true).ToList();
            result.testStandard = _testStandardFacade.GetTestStandard(0).Where(x => x.IsActive == true).ToList();
            result.currency = _currencyFacade.Get().Where(x => x.IsActive == true).ToList();
            result.statusMessage = StatusMessage.Success;
         }
         catch(Exception ex)
         {
            result.StatusCode = ProjectCodes.Error;
            result.StatusMessage = StatusMessage.Error;
         } 
         return Json(result);
      }
      [Authorize]
      [HttpGet]
      public JsonResult GetSearchData()
      {
         PriceAgreementSearchVM obj = new PriceAgreementSearchVM();
         obj.CustomerID = 0;
         obj.AgreementDate = "";
         obj.AgreementToDate = "";
         obj.EffectiveDateFrom = "";
         obj.EffectiveDateTo = "";
         dynamic result = new ExpandoObject();
         try
         {
            result.searchList = _priceAgreementsearchFacade.PriceAgreementSearch(obj);
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
