using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamTreeHouses.Tools
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        /*** Public Part ***/
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //using (MusicStoreEntities storeDb = new MusicStoreEntities())
            //{
            //    ActionLog log = new ActionLog()
            //    {
            //        Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
            //        Action = string.Concat(filterContext.ActionDescriptor.ActionName, " (Logged By: Log Action Filter)"),
            //        IP = filterContext.HttpContext.Request.UserHostAddress,
            //        DateTime = filterContext.HttpContext.Timestamp
            //    };
            //    storeDb.ActionLogs.Add(log);
            //    storeDb.SaveChanges();
            //}
            //filterContext.HttpContext.User.Identity;
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //filterContext.
            base.OnResultExecuting(filterContext);
        }
    }
}