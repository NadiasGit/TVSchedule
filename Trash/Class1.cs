//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Trash
//{
//    public class Class1
//    {

//MY PAGE

//var pers = db.Person.Single(e => e.Id == p);
//var chan = db.Chanel.Single(a => a.Id == c);

//.........................................................................................

//        //MASSOR från programdata

//#region TA BORT?

//---------------TA BORT? -------------------------------------------------------------

//TA BORT?
//public List<FavoriteChannel> AddFavoriteChannel(int person, int channel)
//{
//    var favCannel = db.FavoriteChannel.Where(f => f.Person == person).Where(f => f.Chanel == channel).OrderBy(c => c.Chanel).ToList();
//    var newFavoritChannel = GetFavoriteChannels(person).Where(f => f.Person == person).Where(f => f.Chanel == channel).ToList();
//    //GetFavoriteChannels(id).Add()

//    return favCannel;
//}

////TA Bort?
////public FavoritChannelVM Name(int id, DateTime? date, int? category = null)
////{
////    FilterProgramsByDateAndCategory(date, id);
////    var person = GetPersonById(id);



////    //return finalItem;
////}


////TA BORT?
////public List<Chanel> GetChannels()
////{
////    U4Entities u4 = new U4Entities();

////    var result = u4.Chanel;
////    return result.ToList();
////}

////TA BORT?
//public bool CheckUserCreadentials(string username, string password)
//{
//    var user = db.Person.Where(p => p.UserName == username && p.Password == password).FirstOrDefault();
//    if (user == null)
//    {
//        return false;
//    }
//    return true;
//}




//#endregion




//        //TA BORT?
//        //Metod som hämtar angiven kanal samt kontrollerar dag/datum.
//        public List<Models.db.Program> test(int channel, string date)
//        {
//            U4Entities u4 = new U4Entities();
//            var result = u4.Program.Where(Program => Program.Chanel == channel);
//            var programs = from s in result
//                           select s;
//            switch (date)
//            {
//                case "friday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/10/2017"));
//                    break;
//                case "saturday":
//                    programs = programs.OrderBy(s => s.Starttime == Convert.ToDateTime("11/11/2017"));
//                    break;
//                case "sunday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/12/2017"));
//                    break;
//                case "monday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/13/2017"));
//                    break;
//                case "tuesday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/14/2017"));
//                    break;
//                case "wednesday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/15/2017"));
//                    break;
//                case "thursday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/16/2017"));
//                    break;
//                default:
//                    programs = programs.OrderBy(s => s.Starttime == DateTime.Today);
//                    break;
//            }
//            return programs.ToList();
//        }

//        //Ta bort?
//        public List<Models.db.Program> SortByDate(string sortDate)
//        {

//            var programs = from s in db.Program
//                           select s;
//            switch (sortDate)
//            {
//                case "friday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/10/2017"));
//                    break;
//                case "saturday":
//                    programs = programs.OrderBy(s => s.Starttime == Convert.ToDateTime("11/11/2017"));
//                    break;
//                case "sunday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/12/2017"));
//                    break;
//                case "monday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/13/2017"));
//                    break;
//                case "tuesday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/14/2017"));
//                    break;
//                case "wednesday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/15/2017"));
//                    break;
//                case "thursday":
//                    programs = programs.OrderByDescending(s => s.Starttime == Convert.ToDateTime("11/16/2017"));
//                    break;
//                default:
//                    programs = programs.OrderBy(s => s.Starttime == DateTime.Today);
//                    break;
//            }
//            return programs.ToList();
//        }

//        //List<U4Entities> Svt1List = new List<U4Entities>();

//        //Ta bort?
//        public List<U4Entities> GetProgramDate()
//        {
//            List<U4Entities> ProgramList = new List<U4Entities>();
//            var p = db.Program.Where(Program => Program.Starttime == DateTime.Today);

//            //Forechloop.Alla program i databasen => lägg till i programlista/ kanallista + per dag lista
//            foreach (var i in ProgramList)
//            {
//                ProgramList.Add(i);
//            }

//            return ProgramList.ToList();
//        }

//        public List<Models.db.Program> SVT2()
//        {
//            U4Entities pwdb = new U4Entities();
//            DateTime date2 = DateTime.Today;
//            var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == date2);
//            var dateresult = db.Program.Where(q => q.Starttime == date2);

//            return p.ToList();
//        }

//        public List<Models.db.Program> SVT2Date()
//        {
//            DateTime date2 = DateTime.Today;
//            var dateresult = db.Program.Where(q => q.Starttime == date2);
//            //DateTime dateOnly = date1.Date;

//            return dateresult.ToList();
//        }

//        //Call method for if-statement
//        static void Main()
//        {
//            // Call method with embedded if-statement three times.
//            DateTime date1 = DateTime.Today;

//        }

//        //:::::HÄMTA DATUM-FÖRSÖK::::::::
//        public List<Models.db.Program> SVT1(DateTime sortBy)
//        {
//            U4Entities pwdb = new U4Entities();
//            //DateTime date2 = DateTime.Today;
//            var p = pwdb.Program.Where(Program => Program.Chanel == 1);
//            //var dr = db.Program.Include(q => q.Starttime);

//            return p.ToList();
//            //return p = p.OrderBy(t => t.Starttime).ToList();
//        }

//        //public List<Models.db.Program> ProgramsByChannel()
//        //{

//        //    var p = db.Program.Where(Program => Program.Chanel);

//        //    return p.ToList();
//        //}


//        //Ny metod 15 dec. 2017
//        //Hämtar kanalen via en parameter, en början till att kunna ta bort alla partialViews :)
//        //public List<Program> GetChannel(int channel, DateTime date)
//        //{
//        //    U4Entities u4 = new U4Entities();
//        //    var result = u4.Program.Where(Program => Program.Chanel == channel).Where(q => q.Starttime == date);
//        //    return result.ToList();
//        //}


//        //Mypage controller

//        //var iid = User.Identity.GetUserId();
//        //iid = id.ToString();
//        //int getId = int.Parse(iid);
//        //var channel = pd.GetChannels();
//        //var program = pd.GetPrograms();
//        ////var person = pd.GetPersonById(id);
//        //var user = pr.GetPersonByUserName(name);

//        //var id = pr.GetId(name);


//        //var filter = pd.FilterProgramsByDateAndCategoryMyPage(date);
//        //var filter = pd.FilterProgramsByDateAndCategory(date, category);
//        //var myFav = pd.FilterProgramsByDateAndCategoryMyPage(name, date, category);
//        //finalItem.ProgramListVM = pd.FilterProgramsByDateAndCategoryMyPage(id, date, category);
//        //NY med string date
//        //var ny = pd.FilterProgramsByDAndCategoryMyPage(id, d, category);

//        //finalItem.PersonP = user;
//        //finalItem.ChannelListVM = channel;
//        //finalItem.ProgramListVM = program;



//        //var favoriteChannel = pd.GetFavoriteChannels(id);
//        //finalItem.FavoriteChannelsVM = favoriteChannel;
//        //finalItem.ProgramListVM = ny;

//        //if (Session["UserName"] != null)     int id, 
//        //{

//        //string userId = SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();
//        //string iid = System.Web.HttpContext.Current.User.Identity.GetUserId();
//        //name = User.Identity.Name;

//        //int id = finalItem.PersonP.Id;

//        //else
//        //{
//        //    return RedirectToAction("Login", "LogIn");
//        //}

//        //}

//        //return View(finalItem);


//        //FLYTTA TILL TRASH?/////

//        //Remove favoritechannels
//        //public ActionResult Delete(int? id)
//        //{
//        //    FavoriteChannel favDelete = db.FavoriteChannel.Find(id);
//        //    if (id == null)
//        //    {
//        //        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //        return ViewBag.Message = ("Finns inget att radera...");
//        //    }
//        //    else
//        //    {
//        //        return View(favDelete);
//        //    }
//        //}


//        //FLYTTA TILL TRASH?///////////////////////////

//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult MyFavoriteChannels(FavoriteChannel favorite, int fcid, int id, int chan, string action)
//        //{
//        //    //FavoriteChannel favC, , int channel  , string action
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return HttpNotFound();
//        //    }
//        //    else if (action == "Spara")
//        //    {
//        //        //Add favoritechannel
//        //        int p = id;
//        //        int c = chan;
//        //        //newFavoriteChannel = new FavoriteChannel() { Person = p, Chanel = c};
//        //        favorite = new FavoriteChannel() { Person = p, Chanel = c };

//        //        var pers = db.Person.Single(e => e.Id == id);
//        //        var ch = db.Chanel.Single(a => a.Id == chan);

//        //        //var n = db.FavoriteChannel.Add(newFavoriteChannel);
//        //        db.FavoriteChannel.Add(favorite);


//        //        db.SaveChanges();
//        //        return RedirectToAction("Index", new { @id = id });
//        //    }
//        //    else if (action.Equals("Ta bort som favoritkanal"))
//        //    {
//        //        int f = fcid;
//        //        //newFavoriteChannel = new FavoriteChannel() { Id = fc };
//        //        //var favoriteDelete = db.FavoriteChannel.Find(favchannel.Id);
//        //        //var deleteFavorite = db.FavoriteChannel = favorite;
//        //        //newFavoriteChannel = favorite;
//        //        //favchannelVM.FavoriteChannelsVM = pd.GetFavoriteChannels(id, chan);
//        //        //var channelsDelete = favchannelVM.FavoriteChannelsVM.Where(x => x.Chanel != chan);

//        //        //var channelsDelete = db.FavoriteChannel.Single(x => x.Id == f);

//        //        //db.FavoriteChannel.Remove(channelsDelete);

//        //        var delete = db.FavoriteChannel.Single(x => x.Id == f);
//        //        db.FavoriteChannel.Remove(delete);

//        //        //db.FavoriteChannel.Remove(removeFavoriteChannel);
//        //        db.SaveChanges();

//        //        return RedirectToAction("Index", new { @id = id });
//        //        //Mata ev in , "Index"
//        //        //return RedirectToAction("MyFavoriteChannels", "MyPage", new { @id =favoriteDelete.Id });
//        //        //var favoriteDelete1 = pd.GetFavoriteChannels().SingleOrDefault(i => i.Id == id);
//        //        //favoriteDelete = favchannel;

//        //    }
//        //    return RedirectToAction("MyFavoriteChannels", new { @id = id });
//        //}

//        //

//        //GAMLA INDEX
//        //public ActionResult Index()
//        //{
//        //    var d = pd.SortByDate(date);
//        //    return View(d);
//        //    //NYTT
//        //    var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
//        //    return View(program.ToList()); //ToList = linq /"Program" är inte klassen "Program"  
//        //    //------

//        //    //Gammal kod:
//        //    //return View(); 
//        //}



//        //[HttpPost]
//        //public ActionResult Login(LoginVM model, string ReturnUrl)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        //Skapar en log in cookie som är persistent. Den försvinner när browsern stängs.
//        //        FormsAuthentication.SetAuthCookie(model.UserName, false);
//        //        //FormsAuthentication.SetAuthCookie(model.Password, false);
//        //        return Redirect(ReturnUrl);


//        //    }

//        //    return View();
//        //}

//        //[HttpPost]
//        //public ActionResult Login(GruppG.Models.db.Person pers)
//        //{
//        //    using (U4Entities u4 = new U4Entities())
//        //    {
//        //        var ud = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password).FirstOrDefault();
//        //        if (ud == null)
//        //        {
//        //            pers.Password = "Du har angett fel användarnamn eller lösenord";
//        //            return View("Index", pers);
//        //        }
//        //    }



//        //    return View();

//        //if (ModelState.IsValid)
//        //{
//        //Skapar en log in cookie som är persistent. Den försvinner när browsern stängs.
//        //FormsAuthentication.SetAuthCookie(model.UserName, false);
//        //FormsAuthentication.SetAuthCookie(model.Password, false);
//        //pd.CheckUserCreadentials();

//        //}

//        //    return View();
//        //}



//        //Hämtar alla program till Index-vyn
//        //    @*<table class="table">
//        //    <tr>
//        //        <th>
//        //            <p>Program</p>
//        //        </th>
//        //        <th>
//        //            <p>Tid</p>
//        //        </th>
//        //        <th>
//        //            <p>Kanal</p>
//        //        </th>
//        //    </tr>
//        //    @if(Model != null)
//        //    {
//        //        foreach (var item in Model.ProgramListVM)
//        //        {
//        //            < tr >
//        //                < td > @item.Titel </ td >

//        //                < td >
//        //                        @item.Programstart.Value.ToShortTimeString()
//        //                    </ td >
//        //                    < td > @item.Chanel </ td >

//        //                    < td >
//        //                        @Html.ActionLink("Mer information", "ProgramDetails", new { @id = item.Id }, null)
//        //                    </ td >
//        //            </ tr >
//        //        }
//        //    }
//        //   else
//        //    { 
//        //        <tr><td><h4>Tomt!</h4></td></tr>
//        //    }

//        //</table>*@


//        //if (Channel == null)
//        //{
//        //    ViewBag.Message = ("Nothing to show today :( ... ");           //Fundera ut något bra!
//        //}
//        //else
//        //{
//        //    programList = ProgramRepository.Collection().Where(p => p.Chanel.ToString() == Channel).ToList();
//        //    programChannelVM.Program = db.Program;
//        //}
//        //var program = db.Program.Where(p => p.Chanel.ToString() == Channel).ToList();
//        //var p = programChannelVM.GetChannelPrograms(Channel);
//        //ProgramChannelVM viewModel = new ProgramChannelVM();
//        //viewModel.Program = programList;
//        //viewModel.Channel = channelList;

//        //return View(p);


//        //Länk
//        //<div class="date">
//        //<h4>Filtrera på kategori</h4>
//        //<div class="list-group">
//        //    @Html.ActionLink("Alla kategorier", "Index", null, new { })
//        //    @foreach(var d in Model.CategoryListVM)
//        //{

//        //    @Html.ActionLink(d.Name, "Index", new { id = d.Id }, new { })
//        //    < &nbsp ></ &nbsp >

//        //    }
//        //</div>



//        //GAMLA LOGIN ADMIN

//        //public ActionResult LogInAdmin()
//        //{
//        //    //Log in

//        //    return View();
//        //}


//        //[HttpPost]
//        //public ActionResult LogInAdmin(LoginVM pers)
//        //{
//        //    using (U4Entities u4 = new U4Entities())
//        //    {
//        //        var user = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password && pers.Role ==1).FirstOrDefault();

//        //        if(person.Role == 2)
//        //        {
//        //            pers.LoginErrorMessage = "Du är ej behörig för denna sida";
//        //            return View("LogInAdmin");
//        //        }
//        //        else if (user == null)
//        //        {
//        //            pers.LoginErrorMessage = "Du har angett fel användarnamn eller lösenord";
//        //            return View("LogInAdmin");
//        //        }
//        //        else
//        //        {
//        //            Session["Id"] = user.Id;
//        //            Session["UserName"] = user.UserName.ToString();
//        //            //var p = ue.Person.Where(per => per.Id == user.Id);
//        //            return RedirectToAction("MyPage", "Login");
//        //        }
//        //    }
//        //}


//        //Partial-Views-Channels
//        //     @*<div class="col-md-4">
//        //        <h2>SVT1</h2>

//        //        @{
//        //            Html.RenderAction("SVT1");
//        //        }
//        //@Html.Action("_Channel", "Home", new { channel = 1 , date = "11/11/2017" })

//        //    </div>

//        //    <div class="col-md-4">
//        //        <h2>SVT2</h2>

//        //        @{
//        //            Html.RenderAction("SVT2");
//        //        }
//        //        @Html.Action("_Channel", "Home", new { channel = 2, date = "11/11/2017" })

//        //    </div>
//        //    <div class="col-md-4">
//        //        <h2>TV3</h2>
//        //        @{
//        //            Html.RenderAction("TV3");
//        //        }
//        //    </div>

//        //</div>*@


//        //From Home-Index
//        //        @*@model IEnumerable<GruppG.Models.db.Program>*@
//        //@*@model IEnumerable<GruppG.Models.db.Chanel>*@
//        //@*@model IEnumerable<GruppG.Models.db.U4Entities>*@
//        //@*@model IEnumerable<GruppG.Models.ViewModels.ProgramChannelVM>*@


//        //:::::::Partial views från Home-Controller::::::::::::::::::::::::::::::::::::::


//        //PartialViews ref: https://www.youtube.com/watch?v=SABg7RyjX-4
//        //public ActionResult SVT1()
//        //{
//        //    U4Entities pwdb = new U4Entities();
//        //    var p = pwdb.Program.Where(Program => Program.Chanel == 1).Where(q => q.Starttime == today);

//        //    return PartialView(p.ToList());
//        //}

//        //-------------------------------------

//        //public ActionResult SVT2()
//        //{
//        //    U4Entities pwdb = new U4Entities();
//        //    // (-1) visar gårdagens program :)
//        //    var p = pwdb.Program.Where(Program => Program.Chanel == 2).Where(q => q.Starttime == today);

//        //    return PartialView(p.ToList());
//        //}

//        //--------------------

//        //PartialView TV3
//        //public ActionResult TV3()
//        //{

//        //    U4Entities pwdb = new U4Entities();
//        //    var p = pwdb.Program.Where(Program => Program.Chanel == 3).Where(q => q.Starttime == today);

//        //    return PartialView(p.ToList());
//        //}

//        //--------------------------------------

//        //PartialView TV4
//        //public ActionResult TV4()
//        //{
//        //    U4Entities pwdb = new U4Entities();
//        //    var p = pwdb.Program.Where(Program => Program.Chanel == 4).Where(q => q.Starttime == today);

//        //    return PartialView(p.ToList());
//        //}

//        //--------------------------------------

//        //PartialView Kanal5
//        //public ActionResult Kanal5()
//        //{
//        //    U4Entities pwdb = new U4Entities();
//        //    var p = pwdb.Program.Where(Program => Program.Chanel == 5).Where(q => q.Starttime == today);

//        //    return PartialView(p.ToList());
//        //}


//        //TESTKOD AUTHORIZE

//        //Testkod:
//        //var test = this.pd.UserInRole(httpContext.User.Identity.Name, roles);
//        //var user = httpContext.User;
//        //var allowedRoles = this.Roles.Split(',');
//        //if (!user.Identity.IsAuthenticated)
//        //{
//        //    return false;
//        //}
//        //else
//        //{
//        //    authorize = true;
//        //}
//        //var test = this.pd.UserInRole(httpContext.User.Identity.Name, roles);

//        //------


//        //Nytt 16/12 - Visar specifik kanals program med hjälp av parametern "channel".
//        //public ActionResult _Channel(int channel, DateTime date)
//        //{
//        //    var p = pd.GetChannel(channel, date);
//        //    return PartialView(p);
//        //}


//        //Klassen ChannelData
//        //    public class ChannelData
//        //    {

//        //        private U4Entities db = new U4Entities();

//        //        List<Program> ProgramsToDayList = new List<Program>();

//        //        public List<Program> Today()
//        //        {
//        //            //var today = DateTime.Today;
//        //            var thisDay = db.Program.Where(x => x.Starttime == DateTime.Today);
//        //            //where t.date >= new DateTime(2007, 9, 9) && t.date < new DateTime(2008, 1, 1) select t;
//        //            return thisDay.ToList();

//        //        }

//        //    }
//        //}

//        //public ActionResult Userspage(int id)
//        //{
//        //    var progEdit = db.Person.Single(e => e.Id == id);
//        //    return View(progEdit);
//        //}


//        //public ActionResult PartialViewChannels()
//        //{
//        //    var chan = db.Chanel.Include(c => c.Name);
//        //    var chan1 = db.Chanel;
//        //    return PartialView(chan1.ToList());
//        //}

//        //Save --remove?
//        //public void Commit()
//        //{
//        //    //cache["puffList"] = puffList;
//        //}



//        /*:::::::::::::GET DATES::::::::::::::::::::::*/

//        //public List<DateTime> Dates { get; set; }


//        //public ProgramData()
//        //{
//        //    DateTime Today = new DateTime(2017, 11, 09);

//        //    Dates = new List<DateTime>();
//        //    Dates.Add(Today);
//        //    Dates.Add(Today.AddDays(1));
//        //    Dates.Add(Today.AddDays(2));
//        //    Dates.Add(Today.AddDays(3));
//        //    Dates.Add(Today.AddDays(4));
//        //    Dates.Add(Today.AddDays(5));
//        //    Dates.Add(Today.AddDays(6));

//        //}

//        //Get Dates
//        //public List<DateTime> GetDates()
//        // {
//        //     //DateTimeToday = DateTime.Today;

//        //     //Om vi vill se hårdkodade programmen
//        //     DateTime Today = new DateTime(2017, 11, 09);

//        //     //GetDates() = new List<DateTime>();
//        //     GetDates().Add(Today);
//        //     GetDates().Add(Today.AddDays(1));
//        //     GetDates().Add(Today.AddDays(2));
//        //     GetDates().Add(Today.AddDays(3));
//        //     GetDates().Add(Today.AddDays(4));
//        //     GetDates().Add(Today.AddDays(5));
//        //     GetDates().Add(Today.AddDays(6));

//        //     return GetDates();
//        // }


//        ////Get Dates
//        //public List<DateTime> GetDates()
//        //{
//        //    /*
//        //    //Om vi/du vill ha aktuella datum
//        //    DateTimeToday = DateTime.Today;*/
//        //    //Om vi vill se hårdkodade programmen
//        //    DateTime Today = new DateTime(2017, 11, 09);

//        //    Dates = new List<DateTime>();
//        //    Dates.Add(Today);
//        //    Dates.Add(Today.AddDays(1));
//        //    Dates.Add(Today.AddDays(2));
//        //    Dates.Add(Today.AddDays(3));
//        //    Dates.Add(Today.AddDays(4));
//        //    Dates.Add(Today.AddDays(5));
//        //    Dates.Add(Today.AddDays(6));
//        //    return Dates;
//        //}


//        /*:::::::::::::::::::::::::::::::::::*/


//#region TA BORT?

//----TA BORT? ------------------------ KOMMENTERA UT FÖRST OCH TA BORT VYN INNAN (KONTROLLERA ATT ALLT FUNGERAR)

//public ActionResult Datum(int? id)
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
//public ActionResult PartialViewDetails(int id)
//{
//    return View();
//}

//::::::ÄR DET HÄR FLYTTAT?::::::::::

//Flytta Admin till en egen controller? 18/7-2018
//public ActionResult Admin()
//{
//    var prog = db.Program;
//    return View(prog.ToList());
//}

//public ActionResult AdminProgramEdit(int id)
//{
//    var progEdit = db.Program.Single(e => e.Id == id);
//    return View(progEdit);
//}

//[HttpPost]
//public ActionResult AdminProgramEdit(Program prog)
//{
//    //Ingen vy
//    using (U4Entities editProgram = new U4Entities())
//    {
//        editProgram.Program.Add(prog);
//        editProgram.SaveChanges();
//    }
//    return View();
//}
//---------------------------------------------------------------


//#endregion

//Cockie-försök
//public bool MyCockie(int id)
//{
//    //create a cookie
//    HttpCookie myCookie = new HttpCookie("myCookie");

//    //Add key-values in the cookie
//    myCookie.Values.Add("userid", GetPersonById(id).Id.ToString());
//    return true;
//    //set cookie expiry date-time. Made it to last for next 12 hours.
//    //myCookie.Expires = DateTime.Now.AddHours(12);

//    //Most important, write the cookie to client.
//    //Response.Cookies.Add(myCookie);
//}









//    }
//}
