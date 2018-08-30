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

            //DateTime?
            ProgramChannelVM viewModel = new ProgramChannelVM();
            ProgramChannelVM finalItem = new ProgramChannelVM();
            //ListOfDaysModel Dates = new ListOfDaysModel();
            //SelectedDate selectedDay = new SelectedDate();

            //Början till att få bort nollorna (?)
            //    finalItem.SelectedDate.SelectedDates = Dates.GetDays().Select(d => new SelectListItem
            //    {
            //        Value = d.Id.ToString(),
            //        Text = d.Today.Value.ToShortDateString()
            //}).ToList();

            //DateTime.Parse(date);
            //Convert.ToDateTime(date);


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

        //Nytt 16/12 - Visar specifik kanals program med hjälp av parametern "channel".
        public ActionResult _Channel(int channel, DateTime date)
        {
            var p = pd.GetChannel(channel, date);
            return PartialView(p);
        }
        //------------------------------------------------------------

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