


using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class SpecificationHeadController : Controller
    {
        private readonly ISpecificationHeadFacade _specificationHeadFacade;
        private readonly IMeasurementUnitFacade _measurementUnitFacade;
        public SpecificationHeadController(ISpecificationHeadFacade specificationHeadFacade, IMeasurementUnitFacade measurementUnitFacade)
        {
            this._specificationHeadFacade = specificationHeadFacade;
            _measurementUnitFacade = measurementUnitFacade;
        }
        [Authorize]
        public IActionResult SpecificationHead()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetSpecificationHead()
        {

            var res = new
            {
                headSpecification = _specificationHeadFacade.GetSpecificationHead(),
                measurementList = _measurementUnitFacade.GetMeasurementUnit(0)
            };
            return Json(res);

        }

        [Authorize]
        public IActionResult SpecificationHeadSave(SpecificationHeadVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _specificationHeadFacade.SaveSpecificationHead(obj);
                return Json(result);
            };
            return Json(obj);
        }

    }

}
