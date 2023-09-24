using BMTLLMS.Common;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace BMTLLMS.Web.Controllers
{
    public class SampleTypeController : Controller
    {

        private readonly ISampleTypeFacade _sampleTypeFacade;
        private readonly ISampleCategoryFacade _sampleCategoryFacade;
        public SampleTypeController(ISampleTypeFacade sampleTypeFacade,ISampleCategoryFacade sampleCategoryFacade)
        {
            _sampleTypeFacade = sampleTypeFacade;
            _sampleCategoryFacade = sampleCategoryFacade;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult SampleTypeSave(SampleType sampleType)
        {
            var user = User.Claims.ToList();
            sampleType.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _sampleTypeFacade.SaveSampleType(sampleType);
                return Json(result);
            }
            return View();
        }

        [Authorize]
        public JsonResult GetSampleType()
        {
            return Json(_sampleTypeFacade.Get());
        }
      [Authorize]
      [HttpGet]
      public JsonResult GetInitialData()
      {
         dynamic result = new ExpandoObject();
         try
         {
            result.sampleCategory = _sampleCategoryFacade.GetSampleCategory().Where(x => x.IsActive == true).ToList(); 
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
