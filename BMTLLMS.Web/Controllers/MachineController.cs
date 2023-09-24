using BMTLLMS.Common;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace BMTLLMS.Web.Controllers
{
    public class MachineController : Controller
    {

        private readonly IMachineFacade _machineFacade;
        private readonly IAttributeFacade _attributeFacade;
        public MachineController(IMachineFacade machineFacade, IAttributeFacade attributeFacade)
        {
            _machineFacade = machineFacade;
            _attributeFacade = attributeFacade;
        }
        [Authorize]
        public IActionResult Machine()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult MachineSave(MachineVM Machine)
        {
            var user = User.Claims.ToList();
            Machine.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _machineFacade.SaveMachine(Machine);
                return Json(result);
            }
            return View();
        }

        [Authorize]
        public JsonResult GetMachine()
        {
            return Json(_machineFacade.GetMachine(0));
        }
      [Authorize]
      [HttpGet]
      public JsonResult GetInitialData()
      {
         dynamic result = new ExpandoObject();
         try
         {
            result.attribute = _attributeFacade.GetAttribute(0, 2).Where(x => x.IsActive == true).ToList();
            
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
