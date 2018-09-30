using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TeamTreeHouses.Interfaces;

namespace TeamTreeHouses.Tools
{
    public class ClaimsAuthorizeAttribute : ActionFilterAttribute//, IActionFilter, IAuthorizationFilter
    //: AuthorizeAttribute
    {
        /*** Private Part ***/
        private static void AllowRequest(ActionExecutingContext authContext)
        {
            authContext.Result = null;
            if (!authContext.RequestContext.HttpContext.Request.ServerVariables[@"SERVER_SOFTWARE"].Contains(@"Microsoft-IIS/7."))
                authContext.HttpContext.Response.AddHeader(@"Tenforce-RAuth", @"OK");
            else
                authContext.HttpContext.Response.Headers.Add(@"Tenforce-RAuth", @"OK");
        }

        private static void CancelRequest(ActionExecutingContext authContext)
        {
            authContext.Result = new HttpUnauthorizedResult();
            if (!authContext.RequestContext.HttpContext.Request.ServerVariables[@"SERVER_SOFTWARE"].Contains(@"Microsoft-IIS/7."))
                authContext.HttpContext.Response.AddHeader(@"Tenforce-RAuth", @"DENIED");
            else
                authContext.HttpContext.Response.Headers.Add(@"Tenforce-RAuth", @"DENIED");
        }

        /*** Public Part ***/
        public string Permission { get; set; }
        public static IPermissionManager PermissionManager { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.Result = New RedirectResult("~/Home/Index")
            //
            //HttpResponse.Setup(r => r.AddHeader(It.IsAny<string>(), It.IsAny<string>())).Callback<string, string>((x, y) => HttpResponse.Object.Headers.Add(x, y));
            var lClaimsIdentity = filterContext.HttpContext.User.Identity as ClaimsIdentity;
            //
            if (!lClaimsIdentity.IsAuthenticated)
            #region
            {
                //new HttpResponse() { StatusCode = 403 };
                //filterContext.RequestContext.HttpContext.AddError(new InvalidOperationException("User Is Not Authenticated"));
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Login"},
                    {"action", "Index"}
                });
                return;
            }//end if
            #endregion
            var lId = lClaimsIdentity.FindFirst("Id");
            if (lId == null)
                lId = lClaimsIdentity.FindFirst("UserId");
            if (lId == null)
            #region
            {
                //filterContext.RequestContext.HttpContext.AddError(new InvalidOperationException("User Id Not Found!!!"));
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home"},
                    {"action", "Index"}
                });
                return;
            }//end if
            #endregion
            var lUserId = Convert.ToInt32(lId.Value);
            if (!PermissionManager.HaveAccessToPermission(lUserId, Permission))
            #region
            {
                //filterContext.RequestContext.HttpContext.AddError(new InvalidOperationException("User Not Have Permission"));
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home"},
                    {"action", "Index"}
                });
                return;
            }//end if
            #endregion
            base.OnActionExecuting(filterContext);
        }
    }
}