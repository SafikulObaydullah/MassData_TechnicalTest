using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class ProducerController : Controller
    {

        private readonly IProducerFacade _producerFacade;
        public ProducerController(IProducerFacade producerFacade)
        {
            _producerFacade = producerFacade;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ProducerSave(Producer producer)
        {
            var user = User.Claims.ToList();
            producer.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _producerFacade.SaveProducer(producer);
                return Json(result);
            }
            return View();
        }

        [Authorize]
        public JsonResult GetProducer()
        {
            return Json(_producerFacade.Get());
        }


    }
}
