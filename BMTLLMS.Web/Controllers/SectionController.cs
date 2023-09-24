


using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTLLMS.Web.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionFacade _sectionFacade;
        private readonly ICompanyFacade _companyFacade;
        public SectionController(ISectionFacade sectionFacade, ICompanyFacade companyFacade)
        {
            this._sectionFacade = sectionFacade;
            _companyFacade = companyFacade;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetSection()
        {
            var res = new
            {
                sectionList = _sectionFacade.GetSection(),
                companyList = _companyFacade.GetCompany(0)
            };
            return Json(res);

        }

        [Authorize]
        public IActionResult SectionSave(SectionVM obj)
        {
            var user = User.Claims.ToList();
            obj.Creator = Convert.ToInt64(user[1].Value);
            if (ModelState.IsValid)
            {
                var result = _sectionFacade.SaveSection(obj);
                return Json(result);
            };
            return Json(obj);
        }

    }

}
