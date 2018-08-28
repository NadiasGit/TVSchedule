using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trash
{
    public class Class1
    {
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
    }
}
