using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TeamTreeHouses.Data;
using TeamTreeHouses.Models;
using TeamTreeHouses.Tools;

namespace TeamTreeHouses.Controllers
{
    //http://localhost:5945/ = home page
    //Pattern (Home Page): Controller: Home Action: Index
    //http://localhost:5945/comicbooks/detail = comicbooks/detail is path
    //Pattern = controller/action(Method)
    //
    //[Authorize]
    [LogAction]
    public class ComicBooksController : Controller
    {
        /*** Public Part ***/
        public string Detail() // Action Method
        {
            return "Hello from the comic books controller!!!";
        }

        [HttpPost]
        //[Authorize]
        //[Authorize(Users = "Mohammad")]
        //[Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
            //if (ModelState.IsValid)
            //    return View();
            ////
            //return RedirectToAction("Login");
        }

        public ActionResult ListOfComicBooks()
        {
            return View();
        }

        public ActionResult DetailByView() // Action Method
        {
            ViewBag.DetailOnController = "This Note Sent From Controller On ViewBag!!!";
            return View();
        }

        public ActionResult DetailByContent() // Action Method
        {
            //if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            //    return new RedirectResult("/"); // جهت تغییر مسیر
            ////
            //return new ContentResult()
            //{
            //    ContentEncoding = System.Text.UTF8Encoding.UTF8,
            //    //ContentType 
            //    Content = "Hello from the comic books controller!!!"
            //};
            if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
                return Redirect("/"); // جهت تغییر مسیر
            //
            return Content("Hello from the comic books controller!!!");
        }

        public ActionResult DetailByViewByLayout() // Action Method
        {
            ViewBag.SeriesTitle = "The Amazing Spider-Man";
            ViewBag.IssueNumber = 700;
            ViewBag.Description = "<p>The Amazing Spider-Man Description<p>";
            ViewBag.Artists = new string[]{
              "Script: Dan Scott",
              "Pencils: Humberto Ramos"
            };
            ViewBag.DetailOnController = "This Note Sent From Controller On ViewBag!!!";
            return View();
        }

        public ActionResult AddNewComicBook(ComicBook comicBook)
        {
            if (ModelState.IsValid ||
                ModelState.IsValidField("SeriesTitle"))
            {
                return View();
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public ActionResult DetailByViewOnEntity(int? id) // Action Method
        {
            if (id == null)
                return HttpNotFound();
            //
            var lRepository = new ComicBookRepository();
            ViewBag.DetailOnController = "This Note Sent From Controller On ViewBag!!!";
            var lComicBook = lRepository.GetComicBook(id.GetValueOrDefault(0));
            if (lComicBook == null)
                return HttpNotFound();
            return View(lComicBook);
        }
    }
}