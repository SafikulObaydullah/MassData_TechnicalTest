using BMTLLMS.Common;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace BMTLLMS.Web.Controllers
{
    public class OrderEntryController : Controller
    {

        private readonly ICustomerFacade _customerFacade;
        private readonly ICurrencyFacade _currencyFacade;
        private readonly IProjectFacade _projectFacade;
        private readonly ITestStandardFacade _testStandardFacade;
        private readonly ITestSampleInfoFacade _sampleInfoFacade;
        private readonly IProducerFacade _producerFacade;
        private readonly IPaymentMethodFacade _paymentMethodFacade;
        private readonly IMeasurementUnitFacade _measurementUnitFacade;

        private readonly IOrderEntryFacade _orderEntryFacade;
        public OrderEntryController(IProjectFacade projectFacade, ICustomerFacade customerFacade, ICurrencyFacade currencyFacade, ITestStandardFacade testStandardFacade, ITestSampleInfoFacade sampleInfoFacade, IProducerFacade producerFacade, IPaymentMethodFacade paymentMethodFacade, IOrderEntryFacade orderEntryFacade, IMeasurementUnitFacade measurementUnitFacade)
        {
            _projectFacade = projectFacade;
            _customerFacade = customerFacade;
            _currencyFacade = currencyFacade;
            _testStandardFacade = testStandardFacade;
            _sampleInfoFacade = sampleInfoFacade;
            _producerFacade = producerFacade;
            _paymentMethodFacade = paymentMethodFacade;
            _orderEntryFacade = orderEntryFacade;
            _measurementUnitFacade = measurementUnitFacade;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetInitalData()
        {
            dynamic result = new ExpandoObject();
            try
            { 
                result.customer = _customerFacade.GetCustomer(0).Where(x => x.IsActive == true).ToList();
                result.testStandard = _testStandardFacade.GetTestStandard(0).Where(x => x.IsActive == true).ToList();
                result.currency = _currencyFacade.Get().Where(x => x.IsActive == true).ToList();
                result.project = _projectFacade.GetProject(0).ToList();
                //result.sampleInfo = _sampleInfoFacade.GetTestSampleInfoFacade(0).ToList();
                result.producer = _producerFacade.Get().Where(x => x.isActive == true).ToList();
                result.paymentMethod = _paymentMethodFacade.GetPaymentMethod(0).Where(x => x.IsActive == true).ToList();
                result.measurement = _measurementUnitFacade.GetMeasurementUnit(0).Where(x => x.IsActive == true).ToList();
                result.statusMessage = StatusMessage.Success;
            }
            catch (Exception ex)
            {
                result.StatusCode = ProjectCodes.Error;
                result.StatusMessage = StatusMessage.Error;
            }

            return Json(result);
        }


        [Authorize]
        [HttpPost]
        public IActionResult OrderEntrySave(OrderEntryVM obj)
        {
            try
            {
                var user = User.Claims.ToList();
                obj.Creator = Convert.ToInt64(user[1].Value);
                //if (ModelState.IsValid)
                //{
                //    var result = _orderEntryFacade.SaveOrderEntryFacade(obj);
                //    return Json(result);

                //}
                var result = _orderEntryFacade.SaveOrderEntryFacade(obj);
                return Json(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public JsonResult GetSampleInfoByParam(Int64 CustomerId, Int64 CurrencyCode)
        {
            dynamic result = new ExpandoObject();
            try
            {
              
                result.sampleInfo = _sampleInfoFacade.GetTestSampleInfoFacade(CustomerId, CurrencyCode).ToList();
                result.statusMessage = StatusMessage.Success;
            }
            catch (Exception ex)
            {
                result.StatusCode = ProjectCodes.Error;
                result.StatusMessage = StatusMessage.Error;
            }

            return Json(result);
        }







        [Authorize]
        [HttpPost]
        public JsonResult GetOrderDetail(string GID)
        {
            
            OrderEntrySaveVM result = new OrderEntrySaveVM();
            try
            {
                // result.data = _orderEntryFacade.GetOrderDetail("EB95DBE1-63BE-4BD1-8D2E-B896F693663A").ToList();
                result.data = _orderEntryFacade.GetOrderDetail(GID).ToList();

                result.statusMessage = StatusMessage.Success.ToString();
                result.statusCode = (int)ProjectCodes.Success;
            }
            catch (Exception ex)
            {
                result.statusCode = (int)ProjectCodes.Error;
                result.statusMessage = StatusMessage.Success.ToString();
            }
            return Json(result);
        }




    }
}
