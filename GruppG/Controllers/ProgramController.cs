using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Program
        public ActionResult Index()
        {
            //Startsida. 
            return View();
        }

        //Views
        public ActionResult Tableau()
        {
            //Tv - tablån
            return View();
        }

        //Pariella vyer
        //public ActionResult PartielView()
        //{
        //    Visa populära/rekomendeade program program
        //    return View();
        //}

        //public ActionResult PartielView()
        //{
        //    Visa program per kanal (en partiell vy per kanal)
        //    return View();
        //}

        //public ActionResult PartielView()
        //{
        //    Visa program som visas nu
        //    return View();
        //}



    }
}