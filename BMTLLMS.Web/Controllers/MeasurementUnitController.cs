using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class MeasurementUnitController : Controller
    {
         private readonly IMeasurementUnitFacade _measurementunitFacade;
         public MeasurementUnitController(IMeasurementUnitFacade measurementunitFacade)
         { 
            this._measurementunitFacade = measurementunitFacade;
         }
         [Authorize]
         public IActionResult MeasurementUnit()
         {
            return View();
         }

        [Authorize]
        public JsonResult GetMeasurementUnit()
         {
           var response = new MesurementUnitResponseVM();
             try
             {
                  var result = _measurementunitFacade.GetMeasurementUnit(0);
                  response.Data = result;
                  response.StatusCode = "200";
                  response.StatusMessage = "OK";
             }
             catch(Exception ex)
             {
                   /// Log write 
                  response.StatusCode = "500";
                  response.StatusMessage = ex.ToString();
             }
             return Json(response);
         }
        [Authorize]
        public IActionResult MeasurementUnitSave(MeasurementUnitVM obj)
         {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
             if (ModelState.IsValid)
             {
               var result = _measurementunitFacade.SaveMeasurementUnit(obj);
               return Json(result);
             };
            return Json(obj);  
         }
  
    }

}
