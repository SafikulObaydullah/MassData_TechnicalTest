using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BMTLLMS.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PageAuthorize:Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User.Claims.ToList();
            var UserName = user[0].Value;
            var UserId = user[1].Value;
            var UserType = user[2].Value;
            if (user.Count() < 0)
            {
                context.Result = new RedirectToRouteResult(
                            new RouteValueDictionary
                            {
                            {"action", "Login"},
                            {"controller", "Account"}
                            });
            }
            var routeValues = context.HttpContext.Request.RouteValues;
            var routeValuesList = routeValues.Values.ToList();
            var controllerName = routeValuesList.FirstOrDefault();
            var actionName = routeValuesList.LastOrDefault();
            // Meneu Permission check here
           


        }
    }
}
