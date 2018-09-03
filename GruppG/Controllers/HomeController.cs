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
        
        //NYTT (klassen finns i db-dataModel.Context.tt-dataModel.Context.cs
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
        public ActionResult ProgramDetails(int id, string title)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var prog = pd.GetSpecificProgram(id);

                //För att visa kanalens namn i URL
                title = prog.Chanel1.ToString();
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


        #region TA BORT?

        //----TA BORT? ------------------------ KOMMENTERA UT FÖRST OCH TA BORT VYN INNAN (KONTROLLERA ATT ALLT FUNGERAR)

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

        //------------------------------------------------------------

   
        //------------------------------------------------------------

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Program program = db.Program.Find(id);
        //    if (program == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView(program);
        //}

        // GET: ProgramsCategory/Details/
        /*Den här action-metoden kan vi använda för att visa detaljer om programmen 
        -både från nyhetspuffar och i programtablåerna. */
        public ActionResult PartialViewDetails(int id)
        {
            return View();
        }

        //::::::ÄR DET HÄR FLYTTAT?::::::::::

        //Flytta Admin till en egen controller? 18/7-2018
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
        //---------------------------------------------------------------


        #endregion
    }
}