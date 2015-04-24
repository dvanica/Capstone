using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserDB.Models;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.IO;

namespace UserDB.Controllers
{
    public class BoardController : Controller
    {
        //
        // GET: /Board/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("checkWord")]
        [HttpGet]
        public ActionResult checkWord(string word)
        {
            
            bool wordIsCorrect = true;
            
            //Word cannot be less than 2 characters
            if (word.Length < 2)
                wordIsCorrect = false;
            else
            {
                //RESTFul service call to dictionaryapi.com
                string APIkey = "8900fbbd-4e91-4004-982e-31801fad3db6";
                string baseURL = "http://www.dictionaryapi.com/api/v1/references/collegiate/xml/";

                string URL = baseURL + word + "?key=" + APIkey;
                WebRequest request = WebRequest.Create(URL);
                string xml;
                using (var webClient = new WebClient())
                {
                    xml = webClient.DownloadString(URL);
                }

                using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
                {
                    // TODO:: still need to check for abbreviations, city names, etc.
                    try
                    {
                        if (!reader.ReadToFollowing("entry"))      // if word is not in dictionary, there will be no <entry> tag
                            wordIsCorrect = false;
                    }

                    //If reader fails, the word is defaulted to false
                    catch
                    {
                        // dictionary API sometimes returns improper XML formatting, resulting in error
                        // for example, the query "maai":
                        // http://dictionaryapi.com/api/v1/references/collegiate/xml/maai?key=8900fbbd-4e91-4004-982e-31801fad3db6

                        wordIsCorrect = false;
                    }
                }
            }

            return Json(wordIsCorrect, JsonRequestBehavior.AllowGet);
        }

    }
}
