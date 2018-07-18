﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        //Dessa kommer att tas bort när adtumparametern fungerar
        DateTime yesterday = DateTime.Today.Date.AddDays(-1);
        DateTime today = DateTime.Today;
        DateTime tomorrow = DateTime.Today.Date.AddDays(2);
        //mm/dd/yy
        DateTime friday = Convert.ToDateTime("11/10/2017");
        
      

        

        //NY INDEX:
        public ActionResult Index()
        //public ActionResult Index(string date)
        {
            //var d = pd.SortByDate(date);
            //return View(d);
            //Hämtar alla program i databasen To-do: .OrderByDescending(Chanel1)
            var program = db.Program.Include(p => p.Chanel1);
            return View(program.ToList());

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
            DateTime today = DateTime.Today.Date;
            var thisDay = db.Program.Where(x => x.Starttime == today);
            
            //Lägg till en dag:
            //DateTime.Today.AddDays(1);
            return View(thisDay.ToList());
        }

        public ActionResult PartialViewPuffs()
        {
            var puff = pd.PuffPrograms();
            return PartialView(puff);
        }

        public ActionResult Admin()
        {
            var prog = db.Program;
            return View(prog.ToList());
        }

        public ActionResult AdminProgramEdit(int id)
        {
            var progEdit = db.Program.Single(e => e.Id == id);
            return View(progEdit);
        }

        [HttpPost]
        public ActionResult AdminProgramEdit(Program prog)
        {
            //Ingen vy
            using (U4Entities editProgram = new U4Entities())
            {
                editProgram.Program.Add(prog);
                editProgram.SaveChanges();
            }
            return View();
        }

        public ActionResult ProgramDetails(int id)
        {
            var progEdit = db.Program.Single(e => e.Id == id);
            return View(progEdit);
        }


       

        //------------------------------------------------------------

        //Nytt 16/12 - Visar specifik kanals program med hjälp av parametern "channel".
        public ActionResult _Channel (int channel, DateTime date)
        {
            var p = pd.GetChannel(channel, date);
            return PartialView(p);
        }
        //------------------------------------------------------------
        

        // Hämtar programdetaljer
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


        //Kontakt
        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakta oss:";

            return View();
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





        //PartialViews ref: https://www.youtube.com/watch?v=SABg7RyjX-4
        public ActionResult SVT1()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == today);

            return PartialView(p.ToList());
        }

        //-------------------------------------

        public ActionResult SVT2()
        {
            U4Entities pwdb = new U4Entities();
            // (-1) visar gårdagens program :)
            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == today);

            return PartialView(p.ToList());
        }

        //--------------------

        //PartialView TV3
        public ActionResult TV3()
        {

            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == today);
            //Program SVT1 = pwdb.Program.Where(Program => Program.Chanel == 1);
            return PartialView(p.ToList());
        }

        //--------------------------------------

        //PartialView TV4
        public ActionResult TV4()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == today);

            return PartialView(p.ToList());
        }
       
        //--------------------------------------

        //PartialView Kanal5
        public ActionResult Kanal5()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == today);

            return PartialView(p.ToList());
        }

 

    }
}