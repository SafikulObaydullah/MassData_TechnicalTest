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
    public class PriceAgreementSearchController : Controller
    {
         private readonly IPriceAgreementSearchFacade _priceAgreementSearchFacade;
         public PriceAgreementSearchController(IPriceAgreementSearchFacade priceAgreementSearchFacade)
         {
                    _priceAgreementSearchFacade = priceAgreementSearchFacade;
         } 
         [Authorize]
         public IActionResult PriceAgreementBySearch(PriceAgreementSearchVM obj)
         {
            
            if (obj.CustomerID == null)
            {
               obj.CustomerID = 0;
            }
            if (obj.AgreementDate == null)
            {
               obj.AgreementDate = "";
            }
            if (obj.EffectiveDateFrom == null)
            {
               obj.EffectiveDateFrom = "";
            }
            if (obj.EffectiveDateTo == null)
            {
               obj.EffectiveDateTo = "";
            } 
            return Json(_priceAgreementSearchFacade.PriceAgreementSearch(obj));
         } 
         [HttpPost]
         [Authorize]
         public IActionResult GetPriceAgreementParentAndChildDetails(long id)
         {
            return Json(_priceAgreementSearchFacade.PriceAgreementParentChildDetails(id));
         }
         public JsonResult GetInitialData(long id)
         {
            dynamic result = new ExpandoObject();
            try
            {
               result.priceAgreementDetails = _priceAgreementSearchFacade.PriceAgreementParentChildDetails(id).ToList();
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
