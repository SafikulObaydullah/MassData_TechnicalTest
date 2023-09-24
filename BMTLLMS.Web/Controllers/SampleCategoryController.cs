


using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class SampleCategoryController : Controller
    {
        private readonly ISampleCategoryFacade _sampleCategoryFacade;
        public SampleCategoryController(ISampleCategoryFacade sampleCategoryFacade)
        {
            this._sampleCategoryFacade = sampleCategoryFacade;

        }
        [Authorize]
        public IActionResult SampleCategory()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetSampleCategory()
        {
            return Json(_sampleCategoryFacade.GetSampleCategory());

        }

        [Authorize]
        public IActionResult SampleCategorySave(SampleCategoryVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _sampleCategoryFacade.SaveSampleCategory(obj);
                return Json(result);
            };
            return Json(obj);
        }

    }

}
