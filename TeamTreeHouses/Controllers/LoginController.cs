using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TeamTreeHouses.Models;
using TeamTreeHouses.Tools;

namespace TeamTreeHouses.Controllers
{
    [LogAction]
    public class LoginController : Controller
    {
        /*** Public Part ***/
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [ClaimsAuthorize(Permission = "Set The Permission")]
        public ActionResult AddPermission()
        {
            return View();
        }

        public ActionResult TryLogin(User user)
        {
            using (var lContext = new Models.TreeHouses())
            #region
            {
                var lCurrentUsers = lContext.Users
                    .AsNoTracking()
                    .Where(lUser => lUser.UserName == user.UserName && lUser.Password == user.Password)
                    .Select(x => new
                    {
                        user = x,
                        roles = x.Roles.Where(role => role.IsDeleted == null || role.IsDeleted == false),
                        permissions = x.AdditionalPermission.Where(permission => permission.IsDeleted == null || permission.IsDeleted == false),
                    })
                    .Take(2)
                    .Select(x => x.user);
                if (lCurrentUsers.Count() > 1)
                    return RedirectToAction("Login");
                this.HttpContext.User = lCurrentUsers.FirstOrDefault();
            }//end using
            #endregion
            //
            return RedirectToAction("Index", "Home");
        }

        [ClaimsAuthorize(Permission = "Set The Permission")]
        public ActionResult TryAddPermission(int userId, int permissionId)
        {
            using (var lContext = new TreeHouses())
            #region
            {
                var lUser = lContext.Users.Where(user => user.Id == userId).FirstOrDefault();
                var lPermission = lContext.Permissions.Where(permission => permission.Id == permissionId).FirstOrDefault();
                //
                lUser.AdditionalPermission.Add(lPermission);
                lContext.SaveChanges();
            }//end using
            #endregion
            //
            return RedirectToAction("Index", "Home");
        }
    }
}