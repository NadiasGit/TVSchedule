using System;
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
using GruppG.Models;

namespace GruppG.Controllers
{
    public class HomeController : Controller
    {
        
        private U4Entities db = new U4Entities();
        private ProgramData pd = new ProgramData();
        private Person person = new Person();
        private ProgramChannelVM programChannelVM = new ProgramChannelVM();
        

        public ActionResult Index(DateTime? date, int? id = null)
        {
            ViewBag.Message = ("Inget på TV idag :( ... ");
           
            return View(pd.FilterProgramsByDateAndCategory(date, id));
        }
  

        //Recommended programs (PUFF-list)
        public ActionResult PartialViewPuffs()
        {
            var puff = pd.PuffPrograms();
            return PartialView(puff);
        }

        //ProgramDetails
        public ActionResult ProgramDetails(int id, string chan)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var prog = pd.GetSpecificProgram(id);
                ViewBag.Message = pd.PuffName(prog.Puff);

                return View(prog);
            }     
        }

        //Contact-info
        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakta oss:";

            return View();
        }
        
    }
}