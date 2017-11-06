using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//**NYTT**
//Lagt till dessa för att komma åt db
///using System.Data;
using System.Data.Entity;
using System.Net;
using GruppG.Models.db;
using GruppG.Data;

namespace GruppG.Controllers
{
    public class HomeController : Controller
    {

        //NYTT (klassen finns i db-dataModel.Context.tt-dataModel.Context.cs
        private U4Entities db = new U4Entities();
        private ProgramData pd = new ProgramData();

        public ActionResult Index()
        {   
            //NYTT
            var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
            return View(program.ToList()); //ToList = linq /"Program" är inte klassen "Program"  
            //------

            //Gammal kod:
            //return View(); 
        }

        // GET: ProgramsCategory/Details/
        /*Den här action-metoden kan vi använda för att visa detaljer om programmen 
        -både från nyhetspuffar och i programtablåerna. */
        public ActionResult PartialViewDetails(int id)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Här kan vi visa info om programmen";

            return View();
        }

        //public ActionResult Svt()
        //{
        //    ViewBag.Message = "Här kan vi visa info om programmen";
        //    pd.Svt1L();
        //    return View(pd);
        //}

        public ActionResult PartialViewSvt2()
        {
            //ViewBag.Message = "Här kan vi visa info om programmen";
            //var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
            var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
            return View(program.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakta oss:";

            return View();
        }
    }
}