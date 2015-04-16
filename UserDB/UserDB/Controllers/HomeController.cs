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
        // initialize the UserDB models
        UserDB.Models.UserDB _db = new UserDB.Models.UserDB();

        // When the index.html page is accessed, the UserProfile db is queried for both ASU and UA
        // students. The total score is accumulated for both universities, and an average is taken. The
        // information is then passed to the index.cshtml file to be displayed to the client. 
        [Authorize]
        public ActionResult Index()
        {
            // initialzation of total score and students
            int totalASUStudent = 0, totalUAStudent = 0;
            int totalASU = 0, totalUA = 0; 
            // SqlQueries for all ASU and UofA students
            var modelASU = _db.UserProfiles.SqlQuery("Select * from UserProfile where University= \'ASU\'");
            var modelUA = _db.UserProfiles.SqlQuery("Select * from UserProfile where University= \'UofA\'");

            // for loop to count the number of ASU students and combine all point values
            foreach(var score in modelASU)
            {
                int temp = (int)score.highScore;
                totalASU = totalASU + temp;
                totalASUStudent++;
            }
            // for loop to count the number of UA students and combine all point values
            foreach (var score in modelUA)
            {
                int temp = (int)score.highScore;
                totalUA = totalUA + temp;
                totalUAStudent++;
            }

            // To avoid a divide by zero exception, check to see if the students registered != 0. 
            // Otherwise, take an average of the combined point values and divide by the number of students.
            int asuAverage = 0, uaAverage = 0;
            if(totalASUStudent != 0)
            {
                asuAverage = totalASU / totalASUStudent;
            }
            if(totalUAStudent != 0)
            {
                uaAverage = totalUA / totalUAStudent;
            }

            // Create a list of averages and send them to the view.
            var totals = new List<int>();
            totals.Add(asuAverage);
            totals.Add(uaAverage);
            return View(totals);


        }

        // The User Profile queries the UserProfile db for a specific user and returns the data to the view
        [Authorize]
        public ActionResult Profile()
        {
            // SqlQuery
            var model = _db.UserProfiles.SqlQuery("Select * from UserProfile where UserName = \'" + User.Identity.Name.ToString() + "\'");
            // Return data to view
            return View(model);
        }

        // Method for db disposal
        // The database will be cleaned?
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

        // when a game is finished, UpdateUserScore() receives a score amount from an AJAX call 
        // to update the lastPlayedScore cell in the UserProfile db
        [ActionName("UpdateUserScore")]
        [HttpGet]
        public ActionResult UpdateUserScore(int score)
        {
            // print the score to the log to see if the correct value is returned
            System.Diagnostics.Debug.WriteLine(score);
            // Obtain username
            string name = User.Identity.Name.ToString();
            // LINQ query to get the entity from the db
            UserProfile getEntityFromDatabase = (from x in _db.UserProfiles
                                                where x.UserName == name
                                                select x).First();
            // Modify the entity's score
            getEntityFromDatabase.lastPlayedScore = score;
            // check to see if the score is higher than highScore data.
            // if it is, change the high score as well.
            if(score > getEntityFromDatabase.highScore)
            {
                getEntityFromDatabase.highScore = score;
            }
            // save all db changes
            _db.SaveChanges();
            // return a boolean to show the db has been updated
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // The getUserSchool method returns the user's school in a JSON object in order
        // to change the background image of the game board
        [ActionName("getUserSchool")]
        [HttpGet]
        public ActionResult getUserSchool()
        {
            // get the username
            string name = User.Identity.Name.ToString();
            // LINQ query to get the entity from the UserProfile db
            UserProfile getEntityFromDatabase = (from x in _db.UserProfiles
                                                 where x.UserName == name
                                                 select x).First();
            // set the school to a string
            string school = getEntityFromDatabase.University.ToString();
            // return the data to update the gameboard
            return Json(school, JsonRequestBehavior.AllowGet);
        }
    }
}
