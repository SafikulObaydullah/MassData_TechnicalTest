


using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class TestStandardVsMachineController : Controller
    {
        private readonly ITestStandardVsMachineFacade _testStandardVsMachineFacade;
        private readonly ITestStandardFacade _testStandardFacade;
        private readonly IMachineFacade _machineFacade;
        public TestStandardVsMachineController(ITestStandardVsMachineFacade testStandardVsMachineFacade, ITestStandardFacade testStandardFacade, IMachineFacade machineFacade)
        {
            this._testStandardVsMachineFacade = testStandardVsMachineFacade;
            _testStandardFacade = testStandardFacade;
            _machineFacade = machineFacade;
        }
        [Authorize]
        public IActionResult TestStandardVsMachine()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetTestStandardVsMachine()
        {

         var res = new
         {
            testStandardVsMachineList = _testStandardVsMachineFacade.GetTestStandardVsMachine(),
            testStandardList = _testStandardFacade.GetTestStandard(0),
            machineList = _machineFacade.GetMachine(0)

            };
            return Json(res);

        }

        [Authorize]
        public IActionResult TestStandardVsMachineSave(TestStandardVsMachineVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _testStandardVsMachineFacade.SaveTestStandardVsMachine(obj);
                return Json(result);
            };
            return Json(obj);
        }

    }

}
