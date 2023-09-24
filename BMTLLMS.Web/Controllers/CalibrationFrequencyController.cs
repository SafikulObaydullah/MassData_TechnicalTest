


using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class CalibrationFrequencyController : Controller
    {
        private readonly ICalibrationFrequencyFacade _calibrationFrequencyFacade;
        private readonly IMachineFacade _machineFacade;
        private readonly IMeasurementUnitFacade _measurementUnitFacade;
        public CalibrationFrequencyController(ICalibrationFrequencyFacade calibrationFrequencyFacade, IMeasurementUnitFacade measurementUnitFacade, IMachineFacade machineFacade)
        {
            this._calibrationFrequencyFacade = calibrationFrequencyFacade;
            _machineFacade = machineFacade;
            _measurementUnitFacade = measurementUnitFacade;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetCalibrationFrequency()
        {
            var res = new
            {
                calibrationFrequencyList = _calibrationFrequencyFacade.GetCalibrationFrequency(),
                machineLiast = _machineFacade.GetMachine(0),
                measurementUnitList = _measurementUnitFacade.GetMeasurementUnit(0)
            };
            return Json(res);

        }

        [Authorize]
        public IActionResult CalibrationFrequencySave(CalibrationFrequencyVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _calibrationFrequencyFacade.SaveCalibrationFrequency(obj);
                return Json(result);
            };
            return Json(obj);
        }

    }

}
