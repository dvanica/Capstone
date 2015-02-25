using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserDB.Models;

namespace UserDB.Controllers
{
    public class HomeController : Controller
    {
        UserDB.Models.UserDB _db = new UserDB.Models.UserDB();

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var model = _db.UserProfiles.ToList();
            //model
            return View(model);
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[System.Web.Mvc.Authorize]
        public ActionResult Board()
        {
            return View(new UserDB.Models.Board());
        }
    }
}
