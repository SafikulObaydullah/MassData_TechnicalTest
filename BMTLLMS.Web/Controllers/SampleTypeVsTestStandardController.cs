


using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class SampleTypeVsTestStandardController : Controller
    {
        private readonly ISampleTypeVsTestStandardFacade _sampleTypeVsTestStandardFacade;
        private readonly ISampleTypeFacade _sampleTypeFacade;
        private readonly ITestStandardFacade _testStandardFacade; 



        public SampleTypeVsTestStandardController(ISampleTypeVsTestStandardFacade sampleTypeVsTestStandardFacade, ISampleTypeFacade sampleTypeFacade, ITestStandardFacade testStandardFacade)
        {
            this._sampleTypeVsTestStandardFacade = sampleTypeVsTestStandardFacade;
            _sampleTypeFacade = sampleTypeFacade;
            _testStandardFacade = testStandardFacade;
            _testStandardFacade = testStandardFacade;
        }
        [Authorize]
        public IActionResult SampleTypeVsTestStandard()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetSampleTypeVsTestStandard()
        {

            var res = new
            {
                sampleTypeVsTestStandardList = _sampleTypeVsTestStandardFacade.GetSampleTypeVsTestStandard(),
                sampleTypeList = _sampleTypeFacade.Get(),
                testStandardList = _testStandardFacade.GetTestStandard(0)
            };
            return Json(res);

        }

        [Authorize]
        public IActionResult SampleTypeVsTestStandardSave(SampleTypeVsTestStandardVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _sampleTypeVsTestStandardFacade.SaveSampleTypeVsTestStandard(obj);
                return Json(result);
            };
            return Json(obj);
        }

    }

}
