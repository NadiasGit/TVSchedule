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
        private ChannelData channeldate = new ChannelData();
        private ProgramChannelVM programChannelVM = new ProgramChannelVM();
        private Repository<Program> ProgramRepository = new Repository<Program>();
        private Repository<Chanel> ChannelRepository = new Repository<Chanel>();
        List<Program> programList;

        //Dessa kommer att tas bort när datumparametern fungerar
        DateTime yesterday = DateTime.Today.Date.AddDays(-1);
        DateTime todayGammal = DateTime.Today;
        DateTime tomorrow = DateTime.Today.Date.AddDays(2);
        //mm/dd/yy
        DateTime today = Convert.ToDateTime("11/09/2017");
        



        //var d = pd.SortByDate(date);
        //return View(d);
        //Hämtar alla program i databasen To-do: .OrderByDescending(Chanel1)
        //var program = db.Program.Include(p => p.Chanel1);
        //Chanel c = new Chanel();
        //Program p = new Program();
        //var cp = viewModel.GetChannels();
        //var program = db.Program;
        //foreach (var item in viewModel.GetChannels())
        //{
        //    Channels.Add(item);
        //}
        //List<Chanel> Channels = new List<Chanel>();
        //List<Program> Programs = new List<Program>();

        //NY INDEX:
        public ActionResult Index(DateTime? date, int? id = null)
        {
            ProgramChannelVM viewModel = new ProgramChannelVM();
            ProgramChannelVM finalItem = new ProgramChannelVM();
            ListOfDaysModel Dates = new ListOfDaysModel();
            SelectedDate selectedDay = new SelectedDate();

            //Början till att få bort nollorna (?)
            //    finalItem.SelectedDate.SelectedDates = Dates.GetDays().Select(d => new SelectListItem
            //    {
            //        Value = d.Id.ToString(),
            //        Text = d.Today.Value.ToShortDateString()
            //}).ToList();
            
            ViewBag.Message = ("Inget på TV idag :( ... ");
           
            return View(pd.FilterProgramsByDateAndCategory(date, id));
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
            //Lägg till ett felmeddelande/felhantering om program-id saknas
            //var progEdit = db.Program.Single(e => e.Id == id);
            //var progDetails = programChannelVM.ProgramListVM.Single(d => d.Id == id);
           
            return View(pd.GetSpecificProgram(id));
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
        //public ActionResult SVT1()
        //{
        //    U4Entities pwdb = new U4Entities();
        //    var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == today);

        //    return PartialView(p.ToList());
        //}

        //-------------------------------------

        //public ActionResult SVT2()
        //{
        //    U4Entities pwdb = new U4Entities();
        //    // (-1) visar gårdagens program :)
        //    var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == today);

        //    return PartialView(p.ToList());
        //}

        //--------------------

        //PartialView TV3
        //public ActionResult TV3()
        //{

        //    U4Entities pwdb = new U4Entities();
        //    var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == today);
          
        //    return PartialView(p.ToList());
        //}

        //--------------------------------------

        //PartialView TV4
        //public ActionResult TV4()
        //{
        //    U4Entities pwdb = new U4Entities();
        //    var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == today);

        //    return PartialView(p.ToList());
        //}
       
        //--------------------------------------

        //PartialView Kanal5
        //public ActionResult Kanal5()
        //{
        //    U4Entities pwdb = new U4Entities();
        //    var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == today);

        //    return PartialView(p.ToList());
        //}

 

    }
}