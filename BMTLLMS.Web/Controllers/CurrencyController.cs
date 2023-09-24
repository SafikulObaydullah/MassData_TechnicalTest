using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BMTLLMS.Web.Controllers
{
    public class CurrencyController : Controller
    {

        private readonly ICurrencyFacade _currencyFacade;
        public CurrencyController(ICurrencyFacade currencyFacade)
        {
            _currencyFacade = currencyFacade;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult CurrencySave(Currency currency)
        {
            var user = User.Claims.ToList();
            currency.Creator = Convert.ToInt64(user[1].Value);
            //// Perform model validation
            //if (!ModelState.IsValid)
            //{
            //    // Get the validation errors for the "Name" property
            //    var nameValidationResult = ModelState["Name"]?.Errors.FirstOrDefault();
            //    if (nameValidationResult != null && string.IsNullOrEmpty(nameValidationResult.ErrorMessage))
            //    {
            //        // If there is no error message set, manually add the custom error message to the ModelState
            //        ModelState.AddModelError("Name", "Only alphabets and spaces are allowed.");
            //    }

            //    // Return the view with the model containing the validation errors
            //    ViewData["Name"] = currency.Name;
            //    ViewData["NameError"] = ModelState["Name"]?.Errors.FirstOrDefault()?.ErrorMessage;
            //    return View("YourViewName", currency); // Replace "YourViewName" with the name of your view
            //}

            if (ModelState.IsValid)
            {
                var result = _currencyFacade.SaveCurrency(currency);
                return Json(result);
            }
            // ViewData["NameError"] = ModelState["Name"].Errors.FirstOrDefault()?.ErrorMessage;

            return View();
        }

        [Authorize]
        public JsonResult GetCurrency()
        {
            return Json(_currencyFacade.Get());
        }


    }
}
