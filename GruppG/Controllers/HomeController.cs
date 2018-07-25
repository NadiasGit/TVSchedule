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

namespace GruppG.Controllers
{
    public class HomeController : Controller
    {
        
        //NYTT (klassen finns i db-dataModel.Context.tt-dataModel.Context.cs
        private U4Entities db = new U4Entities();
        private ProgramData pd = new ProgramData();
        private Person person = new Person();
        private ChannelData channeldate = new ChannelData();
        private ProgramChannelVM programChannelVM = new ProgramChannelVM();
        private Repository<Program> ProgramRepository = new Repository<Program>();
        private Repository<Chanel> ChannelRepository = new Repository<Chanel>();

        //Dessa kommer att tas bort när datumparametern fungerar
        DateTime yesterday = DateTime.Today.Date.AddDays(-1);
        DateTime today = DateTime.Today;
        DateTime tomorrow = DateTime.Today.Date.AddDays(2);
        //mm/dd/yy
        DateTime friday = Convert.ToDateTime("11/10/2017");

        

        //NY INDEX:
        public ActionResult Index(int? Channel = null)
        //public ActionResult Index(string date)
        {
            //var d = pd.SortByDate(date);
            //return View(d);
            //Hämtar alla program i databasen To-do: .OrderByDescending(Chanel1)
            //var program = db.Program.Include(p => p.Chanel1);
            //var program = db.Program;
            //return View(program.ToList());
            List<Program> programList;
            List<Chanel> channelList = ChannelRepository.Collection().ToList();

            if (Channel == null)
            {
                throw new Exception("Nothing to show today :( ... ");           //Fundera ut något bra!
            }
            else
            {
                programList = ProgramRepository.Collection().Where(p => p.Chanel == Channel).ToList();
                programChannelVM.Program = db.Program;
            }

            ProgramChannelVM viewModel = new ProgramChannelVM();
            viewModel.Program = programList;
            viewModel.Channel = channelList;

            return View(viewModel);
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