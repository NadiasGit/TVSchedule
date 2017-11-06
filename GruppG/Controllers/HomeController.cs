using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//**NYTT**
//Lagt till dessa för att komma åt db
///using System.Data;
//using System.Data.Entity; - om vi skapat entity
using System.Net;
using GruppG.Models.db;

namespace GruppG.Controllers
{
    public class HomeController : Controller
    {

        

        public ActionResult Index()
        {   
            //NYTT
            //var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
            //return View(program.ToList());
            //------

            //Gammal kod:
            return View(); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Här kan vi visa info om programmen";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakta oss:";

            return View();
        }
    }
}