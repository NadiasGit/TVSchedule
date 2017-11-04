﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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