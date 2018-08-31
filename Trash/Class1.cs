using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trash
{
    public class Class1
    {
        //Mypage controller

        //var iid = User.Identity.GetUserId();
        //iid = id.ToString();
        //int getId = int.Parse(iid);
        //var channel = pd.GetChannels();
        //var program = pd.GetPrograms();
        ////var person = pd.GetPersonById(id);
        //var user = pr.GetPersonByUserName(name);

        //var id = pr.GetId(name);


        //var filter = pd.FilterProgramsByDateAndCategoryMyPage(date);
        //var filter = pd.FilterProgramsByDateAndCategory(date, category);
        //var myFav = pd.FilterProgramsByDateAndCategoryMyPage(name, date, category);
        //finalItem.ProgramListVM = pd.FilterProgramsByDateAndCategoryMyPage(id, date, category);
        //NY med string date
        //var ny = pd.FilterProgramsByDAndCategoryMyPage(id, d, category);

        //finalItem.PersonP = user;
        //finalItem.ChannelListVM = channel;
        //finalItem.ProgramListVM = program;



        //var favoriteChannel = pd.GetFavoriteChannels(id);
        //finalItem.FavoriteChannelsVM = favoriteChannel;
        //finalItem.ProgramListVM = ny;

        //if (Session["UserName"] != null)     int id, 
        //{

        //string userId = SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();
        //string iid = System.Web.HttpContext.Current.User.Identity.GetUserId();
        //name = User.Identity.Name;

        //int id = finalItem.PersonP.Id;

        //else
        //{
        //    return RedirectToAction("Login", "LogIn");
        //}

        //}

        //return View(finalItem);


        //FLYTTA TILL TRASH?/////

        //Remove favoritechannels
        //public ActionResult Delete(int? id)
        //{
        //    FavoriteChannel favDelete = db.FavoriteChannel.Find(id);
        //    if (id == null)
        //    {
        //        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        return ViewBag.Message = ("Finns inget att radera...");
        //    }
        //    else
        //    {
        //        return View(favDelete);
        //    }
        //}


        //FLYTTA TILL TRASH?///////////////////////////

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult MyFavoriteChannels(FavoriteChannel favorite, int fcid, int id, int chan, string action)
        //{
        //    //FavoriteChannel favC, , int channel  , string action
        //    if (!ModelState.IsValid)
        //    {
        //        return HttpNotFound();
        //    }
        //    else if (action == "Spara")
        //    {
        //        //Add favoritechannel
        //        int p = id;
        //        int c = chan;
        //        //newFavoriteChannel = new FavoriteChannel() { Person = p, Chanel = c};
        //        favorite = new FavoriteChannel() { Person = p, Chanel = c };

        //        var pers = db.Person.Single(e => e.Id == id);
        //        var ch = db.Chanel.Single(a => a.Id == chan);

        //        //var n = db.FavoriteChannel.Add(newFavoriteChannel);
        //        db.FavoriteChannel.Add(favorite);


        //        db.SaveChanges();
        //        return RedirectToAction("Index", new { @id = id });
        //    }
        //    else if (action.Equals("Ta bort som favoritkanal"))
        //    {
        //        int f = fcid;
        //        //newFavoriteChannel = new FavoriteChannel() { Id = fc };
        //        //var favoriteDelete = db.FavoriteChannel.Find(favchannel.Id);
        //        //var deleteFavorite = db.FavoriteChannel = favorite;
        //        //newFavoriteChannel = favorite;
        //        //favchannelVM.FavoriteChannelsVM = pd.GetFavoriteChannels(id, chan);
        //        //var channelsDelete = favchannelVM.FavoriteChannelsVM.Where(x => x.Chanel != chan);

        //        //var channelsDelete = db.FavoriteChannel.Single(x => x.Id == f);

        //        //db.FavoriteChannel.Remove(channelsDelete);

        //        var delete = db.FavoriteChannel.Single(x => x.Id == f);
        //        db.FavoriteChannel.Remove(delete);

        //        //db.FavoriteChannel.Remove(removeFavoriteChannel);
        //        db.SaveChanges();

        //        return RedirectToAction("Index", new { @id = id });
        //        //Mata ev in , "Index"
        //        //return RedirectToAction("MyFavoriteChannels", "MyPage", new { @id =favoriteDelete.Id });
        //        //var favoriteDelete1 = pd.GetFavoriteChannels().SingleOrDefault(i => i.Id == id);
        //        //favoriteDelete = favchannel;

        //    }
        //    return RedirectToAction("MyFavoriteChannels", new { @id = id });
        //}

        //

        //GAMLA INDEX
        //public ActionResult Index()
        //{
        //    var d = pd.SortByDate(date);
        //    return View(d);
        //    //NYTT
        //    var program = db.Program.Include(p => p.Chanel1).Include(p => p.Category1);
        //    return View(program.ToList()); //ToList = linq /"Program" är inte klassen "Program"  
        //    //------

        //    //Gammal kod:
        //    //return View(); 
        //}



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



        //Hämtar alla program till Index-vyn
        //    @*<table class="table">
        //    <tr>
        //        <th>
        //            <p>Program</p>
        //        </th>
        //        <th>
        //            <p>Tid</p>
        //        </th>
        //        <th>
        //            <p>Kanal</p>
        //        </th>
        //    </tr>
        //    @if(Model != null)
        //    {
        //        foreach (var item in Model.ProgramListVM)
        //        {
        //            < tr >
        //                < td > @item.Titel </ td >

        //                < td >
        //                        @item.Programstart.Value.ToShortTimeString()
        //                    </ td >
        //                    < td > @item.Chanel </ td >

        //                    < td >
        //                        @Html.ActionLink("Mer information", "ProgramDetails", new { @id = item.Id }, null)
        //                    </ td >
        //            </ tr >
        //        }
        //    }
        //   else
        //    { 
        //        <tr><td><h4>Tomt!</h4></td></tr>
        //    }

        //</table>*@


        //if (Channel == null)
        //{
        //    ViewBag.Message = ("Nothing to show today :( ... ");           //Fundera ut något bra!
        //}
        //else
        //{
        //    programList = ProgramRepository.Collection().Where(p => p.Chanel.ToString() == Channel).ToList();
        //    programChannelVM.Program = db.Program;
        //}
        //var program = db.Program.Where(p => p.Chanel.ToString() == Channel).ToList();
        //var p = programChannelVM.GetChannelPrograms(Channel);
        //ProgramChannelVM viewModel = new ProgramChannelVM();
        //viewModel.Program = programList;
        //viewModel.Channel = channelList;

        //return View(p);


        //Länk
        //<div class="date">
        //<h4>Filtrera på kategori</h4>
        //<div class="list-group">
        //    @Html.ActionLink("Alla kategorier", "Index", null, new { })
        //    @foreach(var d in Model.CategoryListVM)
        //{

        //    @Html.ActionLink(d.Name, "Index", new { id = d.Id }, new { })
        //    < &nbsp ></ &nbsp >

        //    }
        //</div>



        //GAMLA LOGIN ADMIN

        //public ActionResult LogInAdmin()
        //{
        //    //Log in

        //    return View();
        //}


        //[HttpPost]
        //public ActionResult LogInAdmin(LoginVM pers)
        //{
        //    using (U4Entities u4 = new U4Entities())
        //    {
        //        var user = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password && pers.Role ==1).FirstOrDefault();

        //        if(person.Role == 2)
        //        {
        //            pers.LoginErrorMessage = "Du är ej behörig för denna sida";
        //            return View("LogInAdmin");
        //        }
        //        else if (user == null)
        //        {
        //            pers.LoginErrorMessage = "Du har angett fel användarnamn eller lösenord";
        //            return View("LogInAdmin");
        //        }
        //        else
        //        {
        //            Session["Id"] = user.Id;
        //            Session["UserName"] = user.UserName.ToString();
        //            //var p = ue.Person.Where(per => per.Id == user.Id);
        //            return RedirectToAction("MyPage", "Login");
        //        }
        //    }
        //}


        //Partial-Views-Channels
        //     @*<div class="col-md-4">
        //        <h2>SVT1</h2>

        //        @{
        //            Html.RenderAction("SVT1");
        //        }
        //@Html.Action("_Channel", "Home", new { channel = 1 , date = "11/11/2017" })

        //    </div>

        //    <div class="col-md-4">
        //        <h2>SVT2</h2>

        //        @{
        //            Html.RenderAction("SVT2");
        //        }
        //        @Html.Action("_Channel", "Home", new { channel = 2, date = "11/11/2017" })

        //    </div>
        //    <div class="col-md-4">
        //        <h2>TV3</h2>
        //        @{
        //            Html.RenderAction("TV3");
        //        }
        //    </div>

        //</div>*@


        //From Home-Index
        //        @*@model IEnumerable<GruppG.Models.db.Program>*@
        //@*@model IEnumerable<GruppG.Models.db.Chanel>*@
        //@*@model IEnumerable<GruppG.Models.db.U4Entities>*@
        //@*@model IEnumerable<GruppG.Models.ViewModels.ProgramChannelVM>*@


        //:::::::Partial views från Home-Controller::::::::::::::::::::::::::::::::::::::


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


        //TESTKOD AUTHORIZE

        //Testkod:
        //var test = this.pd.UserInRole(httpContext.User.Identity.Name, roles);
        //var user = httpContext.User;
        //var allowedRoles = this.Roles.Split(',');
        //if (!user.Identity.IsAuthenticated)
        //{
        //    return false;
        //}
        //else
        //{
        //    authorize = true;
        //}
        //var test = this.pd.UserInRole(httpContext.User.Identity.Name, roles);

        //------


    }
}
