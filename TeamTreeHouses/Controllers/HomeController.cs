using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamTreeHouses.Tools;

namespace TeamTreeHouses.Controllers
{
    [LogAction]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        /*** Public Part ***/
        [AllowAnonymous]
        public ActionResult Index()
        {
            using (var lContext = new Models.TreeHouses())
                return View(lContext.ComicBooks.ToList());
        }
    }
}