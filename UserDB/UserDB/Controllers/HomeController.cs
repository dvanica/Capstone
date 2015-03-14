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
            int totalASU = 0, totalUA = 0; 
            var modelASU = _db.UserProfiles.SqlQuery("Select * from UserProfile where University= \'ASU\'");
            var modelUA = _db.UserProfiles.SqlQuery("Select * from UserProfile where University= \'UA\'");

            foreach(var score in modelASU)
            {
                int temp = (int)score.highScore;
                totalASU = totalASU + temp;
            }

            foreach (var score in modelUA)
            {
                int temp = (int)score.highScore;
                totalUA = totalUA + temp;
            }

            var totals = new List<int>();
            totals.Add(totalASU);
            totals.Add(totalUA);
            return View(totals);


        }

        [Authorize]
        public ActionResult Profile()
        {
            //change 
            var model = _db.UserProfiles.SqlQuery("Select * from UserProfile where UserName = \'" + User.Identity.Name.ToString() + "\'");
            
            return View(model);
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
