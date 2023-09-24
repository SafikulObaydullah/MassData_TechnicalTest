using BMTLLMS.Common;
using BMTLLMS.Common.Security;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Request.API;
using BMTLLMS.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace BMTLLMS.Web.Controllers
{

    public class MobileAppsController : Controller
    {
        IConfiguration _configurations;
        ITestFacade _testFacade;
        public MobileAppsController(IConfiguration configurations,ITestFacade testFacade)
        {
          
            _configurations = configurations;
            _testFacade = testFacade;
          
        }
        [HttpGet]
        public async Task<IActionResult> TestDataEntryUserDashboard()
        {
            const string HeaderKeyName = "token";
            string Header = Request.Headers[HeaderKeyName];
            dynamic ResultResponse = new ExpandoObject();
            int UserId = 0;
            try
            {
                    if (string.IsNullOrEmpty(Header))
                {
                    ResultResponse.statusCode = ProjectCodes.Unauthorized;
                    ResultResponse.statusMessage = ProjectMessage._tokenInvaild;
                }
                else
                {
                  var  userauthorizetoken = TextEncryptionDecryption.Decrypt(Header, _configurations["EncryptionKeys:Key4"].ToString());
                    string[] UserToken = userauthorizetoken.Split("#");
                    UserId = Convert.ToInt32(UserToken[0]);
                }
           
          
                var result = await _testFacade.GetTestEntryDashboardFacade(UserId);
                ResultResponse.statusCode = ProjectCodes.Success;
                ResultResponse.statusMessage = ProjectMessage._commonSuccessMessage;
                ResultResponse.data = result;
            }
            catch (Exception ex)
            {
                ResultResponse.statusCode = ProjectCodes.Error;
                ResultResponse.statusMessage = ProjectMessage._commonErrorMessage;
            }
            return  Ok (await Task.FromResult(ResultResponse));
        }
        [HttpPost]
        public async Task<IActionResult> TestDataEntryListByUser([FromBody]TestDataByStatusRequest Obj)
        {
            const string HeaderKeyName = "token";
            string Header = Request.Headers[HeaderKeyName];
            dynamic ResultResponse = new ExpandoObject();
            int UserId = 0;
            try
            {
                if (string.IsNullOrEmpty(Header))
                {
                    ResultResponse.statusCode = ProjectCodes.Unauthorized;
                    ResultResponse.statusMessage = ProjectMessage._tokenInvaild;
                }
                else
                {
                    var userauthorizetoken = TextEncryptionDecryption.Decrypt(Header, _configurations["EncryptionKeys:Key4"].ToString());
                    if (string.IsNullOrEmpty(userauthorizetoken))
                    {
                        ResultResponse.statusCode = ProjectCodes.Unauthorized;
                        ResultResponse.statusMessage = ProjectMessage._tokenInvaild;
                        return Ok(await Task.FromResult(ResultResponse));
                    }
                    else
                    {
                        string[] UserToken = userauthorizetoken.Split("#");
                        UserId = Convert.ToInt32(UserToken[0]);
                    }
                }
         
           
                var result = await _testFacade.GetUserWiseTestAssignFacade(UserId,Obj.Status);
                ResultResponse.statusCode = ProjectCodes.Success;
                ResultResponse.statusMessage = ProjectMessage._commonSuccessMessage;
                ResultResponse.data = result;
            }
            catch (Exception ex)
            {
                ResultResponse.statusCode = ProjectCodes.Error;
                ResultResponse.statusMessage = ProjectMessage._commonErrorMessage;
            }
            return Ok(await Task.FromResult(ResultResponse));
        }
    }
}
