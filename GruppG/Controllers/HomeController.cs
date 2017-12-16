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
        DateTime yesterday = DateTime.Today.Date.AddDays(-1);
        DateTime today = DateTime.Today;
        DateTime tomorrow = DateTime.Today.Date.AddDays(2);
        //mm/dd/yy
        DateTime friday = Convert.ToDateTime("11/10/2017");
        DateTime saturday = Convert.ToDateTime("11/11/2017");
        DateTime sunday = Convert.ToDateTime("11/12/2017");
        DateTime monday = Convert.ToDateTime("11/13/2017");
        DateTime tuesday = Convert.ToDateTime("11/14/2017");
        DateTime wednesday = Convert.ToDateTime("11/15/2017");
        DateTime thursday = Convert.ToDateTime("11/16/2017");
        

        public ActionResult Index()
        {   
            //NYTT
            var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
            return View(program.ToList()); //ToList = linq /"Program" är inte klassen "Program"  
            //------

            //Gammal kod:
            //return View(); 
        }
        public ActionResult Friday()
        {
            return View();
        }
        public ActionResult Saturday()
        {
            return View(); 
        }
        public ActionResult Sunday()
        {
            return View();
        }
        public ActionResult Monday()
        {
            return View();
        }
        public ActionResult Tuesday()
        {
            return View();
        }
        public ActionResult Wednesday()
        {
            return View();
        }
        public ActionResult Thursday()
        {
            return View();
        }
        //------------------------------------------------

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

        //Nytt 16/12
        public ActionResult _Channel (int channel)
        {
            var p = pd.GetChannel(channel);
            return PartialView(p);
        }
        //------------------------------------------------------------

        //PartialViews ref: https://www.youtube.com/watch?v=SABg7RyjX-4
        public ActionResult SVT1()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == today);

            return PartialView(p.ToList());
        }
        public ActionResult SVT1friday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == friday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT1saturday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == saturday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT1sunday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == sunday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT1monday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == monday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT1tuesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == tuesday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT1wednesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == wednesday);

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
        public ActionResult SVT2friday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == friday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT2saturday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == saturday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT2sunday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == sunday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT2monday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == monday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT2tuesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == tuesday);

            return PartialView(p.ToList());
        }
        public ActionResult SVT2wednesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == wednesday);

            return PartialView(p.ToList());
        }
        //--------------------

        //PartialView TV3
        public ActionResult TV3()
        {

            U4Entities pwdb = new U4Entities();

            
            var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == friday);
            //Program SVT1 = pwdb.Program.Where(Program => Program.Chanel == 1);

            return PartialView(p.ToList());
        }

        public ActionResult TV3friday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == friday);

            return PartialView(p.ToList());
        }
        public ActionResult TV3saturday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == saturday);

            return PartialView(p.ToList());
        }
        public ActionResult TV3sunday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == sunday);

            return PartialView(p.ToList());
        }
        public ActionResult TV3monday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == monday);

            return PartialView(p.ToList());
        }
        public ActionResult TV3tuesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == tuesday);

            return PartialView(p.ToList());
        }
        public ActionResult TV3wednesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == wednesday);

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

        public ActionResult TV4friday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == friday);
          
            return PartialView(p.ToList());
        }
        public ActionResult TV4saturday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == saturday);

            return PartialView(p.ToList());
        }
        public ActionResult TV4sunday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == sunday);

            return PartialView(p.ToList());
        }
        public ActionResult TV4monday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == monday);

            return PartialView(p.ToList());
        }
        public ActionResult TV4tuesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == tuesday);

            return PartialView(p.ToList());
        }
        public ActionResult TV4wednesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == wednesday);

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

        public ActionResult Kanal5friday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == today);
          
            return PartialView(p.ToList());
        }
        public ActionResult Kanal5saturday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == saturday);

            return PartialView(p.ToList());
        }
        public ActionResult Kanal5sunday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == sunday);

            return PartialView(p.ToList());
        }
        public ActionResult Kanal5monday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == monday);

            return PartialView(p.ToList());
        }
        public ActionResult Kanal5tuesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == tuesday);

            return PartialView(p.ToList());
        }
        public ActionResult Kanal5wednesday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == wednesday);

            return PartialView(p.ToList());
        }
        public ActionResult Kanal5thursday()
        {
            U4Entities pwdb = new U4Entities();
            var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == wednesday);
           
            return PartialView(p.ToList());
        }
        public ActionResult NoProgram()
        {
            return PartialView();
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