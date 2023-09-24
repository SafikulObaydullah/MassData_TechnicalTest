using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BMTLLMS.Web.Attributes;
using BMTLLMS.Web.Models;

namespace BMTLLMS.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [PageAuthorize]
    [Authorize]
    public IActionResult Index()
    {
        var user = User.Claims.ToList();
        var UserName = user[0].Value;
        var UserId = user[1].Value;
        var UserType = user[2].Value;
        return View();
    }

   
}
