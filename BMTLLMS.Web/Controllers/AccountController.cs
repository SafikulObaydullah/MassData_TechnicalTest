using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BMTLLMS.Domain.Models.Request;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Common.Security;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using BMTLLMS.Domain.ViewModel.Request;
using System.Dynamic;
using BMTLLMS.Common;
using BMTLLMS.Domain.ViewModel.Response.Login;

namespace BMTLLMS.Web.Controllers
{
    public class AccountController : Controller
    {
      IHttpContextAccessor _Accessor;
      IConfiguration _configurations;

      private readonly IAccountFacade _accountFacade;
        public AccountController(IHttpContextAccessor Accessor, IConfiguration configurations, IAccountFacade accountFacade)
         {
            _Accessor = Accessor;
            _configurations = configurations;
            _accountFacade = accountFacade;
         }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login o)
        {
            try
            {
                o.Password = TextEncryptionDecryption.Encrypt(o.Password, _configurations["EncryptionKeys:Key2"].ToString());
                var user = _accountFacade.GetAuthenticUserData(o).FirstOrDefault();
                if (user != null)
                {



                    var claims = new[] {
                    new Claim("name", user.Name),
                    new Claim("userid", user.ID.ToString()),
                    new Claim("Designation", user.Designation),
                    new Claim("UserTypeID", user.UserTypeAttributeID.ToString()),
                    new Claim("UserSectionID", user.UserSectionID.ToString())
                };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.errormsg = "Invalid User Name or Password"; 
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.errormsg = "Fail to login, please try again.";
                return View();
            }

        }

        [HttpPost]
        //public IActionResult Login(Login o)
        //{



        //   //var user = _accountFacade.GetAuthenticUserData(o).FirstOrDefault();
        //   if (o.Username == "admin" && o.Password == "123")
        //   {

        //      var claims = new[] {
        //            new Claim("name", "Sarder Iftekhar Ahmed"),
        //            new Claim("userid", "1") ,
        //            new Claim("userType", "1"),
        //            new Claim("designation","Software Engineer")

        //        };
        //      var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //      HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        //      return RedirectToAction("Index", "Home");
        //   }
        //   else
        //   {
        //      ViewBag.errormsg = "Wrong User Name or Password";
        //      return View();
        //   }
        //}
        [HttpGet]
      public IActionResult LogOff()
        {
           
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> MLogin([FromBody]MLogin User)
        {
            dynamic loginResponse = new ExpandoObject();
            try
            {
                User.Password = TextEncryptionDecryption.Encrypt(User.Password, _configurations["EncryptionKeys:Key2"].ToString());
                IEnumerable<LoginUser> user = await _accountFacade.GetAuthenticUserDataAsync(User);
                if (user.Count()>0)
                {
                    var ExpiryTime = DateTime.Now.AddDays(1);
                    var userauthorizetoken = user.FirstOrDefault().ID.ToString() + "#" + user.FirstOrDefault().Password.ToString() + "#" + ExpiryTime.ToString("yyyy-MM-dd");

                    userauthorizetoken = TextEncryptionDecryption.Encrypt(userauthorizetoken, _configurations["EncryptionKeys:Key4"].ToString());
                    dynamic UserObj = new ExpandoObject();
                    UserObj.id = user.FirstOrDefault().ID;
                    UserObj.name = user.FirstOrDefault().Name;
                    UserObj.designation = user.FirstOrDefault().Designation;
                    UserObj.section = user.FirstOrDefault().UserSectionName; 
                    UserObj.userType = user.FirstOrDefault().UserTypeAttributeName;
                    UserObj.token = userauthorizetoken;
                    UserObj.email = user.FirstOrDefault().Email;
                    UserObj.userName = user.FirstOrDefault().UserName;
                    loginResponse.statusCode = (int)ProjectCodes.Success;
                    loginResponse.statusMessage = ProjectMessage._loginSuccess;
                  
                    loginResponse.data = UserObj;

                }
                else
                {
                    loginResponse.statusCode = (int)ProjectCodes.NotFound;
                    loginResponse.statusMessage = ProjectMessage._loginInvaild;
                }


            }
            catch(Exception ex)
            {
                loginResponse.statusCode = (int)ProjectCodes.Error;
                loginResponse.statusMessage = ProjectMessage._commonErrorMessage;
            }

            
            return Ok( await Task.FromResult( loginResponse));
        }
    }
}
