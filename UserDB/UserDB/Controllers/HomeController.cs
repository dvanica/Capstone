using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using UserDB.Models;
using System.Data.Entity.Migrations; 

namespace UserDB.Controllers
{
    public class HomeController : Controller
    {
        UserDB.Models.UserDB _db = new UserDB.Models.UserDB();

        [Authorize]
        public ActionResult Index()
        {
            int totalASUStudent = 0, totalUAStudent = 0;
            int totalASU = 0, totalUA = 0; 
            var modelASU = _db.UserProfiles.SqlQuery("Select * from UserProfile where University= \'ASU\'");
            var modelUA = _db.UserProfiles.SqlQuery("Select * from UserProfile where University= \'UA\'");

            foreach(var score in modelASU)
            {
                int temp = (int)score.highScore;
                totalASU = totalASU + temp;
                totalASUStudent++;
            }

            foreach (var score in modelUA)
            {
                int temp = (int)score.highScore;
                totalUA = totalUA + temp;
                totalUAStudent++;
            }

            int asuAverage = 0, uaAverage = 0;
            if(totalASUStudent != 0)
            {
                asuAverage = totalASU / totalASUStudent;
            }
            if(totalUAStudent != 0)
            {
                uaAverage = totalUA / totalUAStudent;
            }

            var totals = new List<int>();
            totals.Add(asuAverage);
            totals.Add(uaAverage);
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

        [System.Web.Mvc.Authorize]
        public ActionResult Board()
        {
            return View(new UserDB.Models.Board());
        }

        [ActionName("UpdateUserScore")]
        [HttpGet]
        public ActionResult UpdateUserScore(int score)
        {
            System.Diagnostics.Debug.WriteLine(score);
            string name = User.Identity.Name.ToString();
            // Score prints but the db does not update???
            UserProfile getEntityFromDatabase = (from x in _db.UserProfiles
                                         where x.UserName == name
                                         select x).First();
            getEntityFromDatabase.lastPlayedScore = score;
            if(score > getEntityFromDatabase.highScore)
            {
                getEntityFromDatabase.highScore = score;
            }
            _db.SaveChanges();
            System.Diagnostics.Debug.WriteLine(Json(true, JsonRequestBehavior.AllowGet));
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
