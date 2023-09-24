using BMTLLMS.Common;
using BMTLLMS.Common.Security;
using BMTLLMS.Domain.Models.Request;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace BMTLLMS.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IAccountFacade _accountFacade;
        IConfiguration _configurations;
        public AccountController(IAccountFacade accountFacade, IConfiguration configurations)
        {
            _accountFacade = accountFacade;
            _configurations = configurations;
        }
       
        [HttpPost]
        public async Task<IActionResult> MLogin(MLogin User)
        {
            dynamic loginResponse = new ExpandoObject();
            try
            {
                User.Password = TextEncryptionDecryption.Encrypt(User.Password, _configurations["EncryptionKeys:Key2"].ToString());
                IEnumerable<LoginUser> user = await _accountFacade.GetAuthenticUserDataAsync(User);
                if (user.Count() > 0)
                {
                    var ExpiryTime = DateTime.Now.AddDays(1);
                    var userauthorizetoken = user.FirstOrDefault().ID.ToString() + "#" + user.FirstOrDefault().Password.ToString() + "#" + ExpiryTime.ToString("yyyy-MM-dd");

                    userauthorizetoken = TextEncryptionDecryption.Encrypt(userauthorizetoken, _configurations["EncryptionKeys:Key4"].ToString());
                    dynamic UserObj = new ExpandoObject();
                    UserObj.name = user.FirstOrDefault().Name;
                    UserObj.designation = user.FirstOrDefault().Designation;
                    UserObj.section = user.FirstOrDefault().UserSectionName;
                    UserObj.userType = user.FirstOrDefault().UserTypeAttributeName;

                    loginResponse.statusCode = (int)ProjectCodes.Success;
                    loginResponse.statusMessage = ProjectMessage._loginSuccess;
                    loginResponse.token = userauthorizetoken;
                    loginResponse.data = UserObj;

                }
                else
                {
                    loginResponse.statusCode = (int)ProjectCodes.NotFound;
                    loginResponse.statusMessage = ProjectMessage._loginInvaild;
                }


            }
            catch (Exception ex)
            {
                loginResponse.statusCode = (int)ProjectCodes.Error;
                loginResponse.statusMessage = ProjectMessage._commonErrorMessage;
            }


            return Ok(await Task.FromResult(loginResponse));
        }
    }
}
