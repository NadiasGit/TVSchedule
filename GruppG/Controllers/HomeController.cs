﻿using System;
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
using GruppG.Models.ViewModels;
using System.Web.Security;

namespace GruppG.Controllers
{
    public class HomeController : Controller
    {
        
        //NYTT (klassen finns i db-dataModel.Context.tt-dataModel.Context.cs
        private U4Entities db = new U4Entities();
        private ProgramData pd = new ProgramData();
        private Person person = new Person();
        private ChannelData channeldate = new ChannelData();

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
            var today = DateTime.Today;
            var thisDay = db.Program.Where(x => x.Starttime == today);

            //ViewBag.Message = "Här kan vi visa info om programmen";
            //var model = channeldate.Today();
            return View(thisDay.ToList());
        }

        public ActionResult SVT1()
        {
            U4Entities pwdb = new U4Entities();
            DateTime date1 = DateTime.Today;
            
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == date1);
            //.Where(p => p.Starttime.Equals("2017,11,08")
            //var p = pwdb.Program.Where(Program => Program.Chanel == 1);

            return PartialView(p.ToList());
        }

        public ActionResult PartialViewSvt2()
        {
            //ViewBag.Message = "Här kan vi visa info om programmen";
            //var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
            var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
            return PartialView(program.ToList());
        }

        //PartialView som visar TV3s tablå
        public ActionResult TV3()
        {

            U4Entities pwdb = new U4Entities();

            var p = pwdb.Program.Where(Program => Program.Chanel == 3);
            //Program SVT1 = pwdb.Program.Where(Program => Program.Chanel == 1);

            return PartialView(p.ToList());

        }

        public ActionResult TV4()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 4);

            return View(p.ToList());
        }

        public ActionResult Kanal5()
        {
            
            U4Entities pwdb = new U4Entities();
            var kanal5 = pwdb.Program.Where(Program => Program.Chanel == 5);

            return PartialView(kanal5.ToList());
        }


        // Hämta programmets details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Program.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return PartialView(program);
        }

        public ActionResult Datum(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Program.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return PartialView(program);
        }







      

        //[HttpPost]
        //public ActionResult Login(LoginVM model, string ReturnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Skapar en log in cookie som är persistent. Den försvinner när browsern stängs.
        //        FormsAuthentication.SetAuthCookie(model.UserName, false);
        //        //FormsAuthentication.SetAuthCookie(model.Password, false);
        //        return Redirect(ReturnUrl);


        //    }

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(GruppG.Models.db.Person pers)
        //{
        //    using (U4Entities u4 = new U4Entities())
        //    {
        //        var ud = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password).FirstOrDefault();
        //        if (ud == null)
        //        {
        //            pers.Password = "Du har angett fel användarnamn eller lösenord";
        //            return View("Index", pers);
        //        }
        //    }



        //    return View();

        //if (ModelState.IsValid)
        //{
        //Skapar en log in cookie som är persistent. Den försvinner när browsern stängs.
        //FormsAuthentication.SetAuthCookie(model.UserName, false);
        //FormsAuthentication.SetAuthCookie(model.Password, false);
        //pd.CheckUserCreadentials();

        //}

        //    return View();
        //}

       

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakta oss:";

            return View(); 
        }
    }
}