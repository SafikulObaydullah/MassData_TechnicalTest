using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class PriceAgreementChildController : Controller
    {

        private readonly IPriceAgreementChildFacade _priceAgreementChildFacade;
        public PriceAgreementChildController(IPriceAgreementChildFacade priceAgreementChildFacade)
        {
             _priceAgreementChildFacade = priceAgreementChildFacade;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult PriceAgreementChildSave(PriceAgreementChildVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _priceAgreementChildFacade.SavePriceAgreementChildFacade(obj);
                return Json(result);
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public JsonResult GetPriceAgreementChild()
        {
            return Json(_priceAgreementChildFacade.GetPriceAgreementChildFacade(0));
        }
    }
}
