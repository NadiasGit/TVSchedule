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

        //PartialView som visar TV3s tablå
        public ActionResult PartialViewTV3()
        {

            U4Entities pwdb = new U4Entities();

            var p = pwdb.Program.Where(Program => Program.Chanel == 3);
            //Program SVT1 = pwdb.Program.Where(Program => Program.Chanel == 1);

            return View(p.ToList());

        }

        public ActionResult PartialViewKanal5()
        {

            U4Entities pwdb = new U4Entities();
            var kanal5 = pwdb.Program.Where(Program => Program.Chanel == 5);

            return View(kanal5.ToList());
        }

        public ActionResult LogIn()
        {
            //Log in

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        public ActionResult MyPage()
        {
            //Visitor or admins page
            //var myChannel = db.Chanel.Include(p => p.Name);
            return View(db.Chanel.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakta oss:";

            return View();
        }
    }
}