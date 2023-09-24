


using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class SampleTypeVsSpecificationTypeController : Controller
    {
        private readonly ISampleTypeVsSpecificationTypeFacade _sampleTypeVsSpecificationTypeFacade;
        private readonly ISampleTypeFacade _sampleTypeFacade;
        private readonly ISpecificationHeadFacade _specificationHeadFacade;
        public SampleTypeVsSpecificationTypeController(ISampleTypeVsSpecificationTypeFacade sampleTypeVsSpecificationTypeFacade, ISampleTypeFacade sampleTypeFacade, ISpecificationHeadFacade specificationHeadFacade)
        {
            this._sampleTypeVsSpecificationTypeFacade = sampleTypeVsSpecificationTypeFacade;
            _sampleTypeFacade = sampleTypeFacade;
            _specificationHeadFacade = specificationHeadFacade;
        }
        [Authorize]
        public IActionResult SampleTypeVsSpecificationType()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetSampleTypeVsSpecificationType()
        {

            var res = new
            {
                smapleTypeVsSpecificationTypeList = _sampleTypeVsSpecificationTypeFacade.GetSampleTypeVsSpecificationType(),
                sampleTypeList = _sampleTypeFacade.Get(),
                specificationHeadList = _specificationHeadFacade.GetSpecificationHead()

            };
            return Json(res);

        }

        [Authorize]
        public IActionResult SampleTypeVsSpecificationTypeSave(SampleTypeVsSpecificationTypeVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _sampleTypeVsSpecificationTypeFacade.SaveSampleTypeVsSpecificationType(obj);
                return Json(result);
            };
            return Json(obj);
        }

    }

}
