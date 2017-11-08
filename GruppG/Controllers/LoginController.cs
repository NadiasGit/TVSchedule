using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GruppG.Models.ViewModels;
using System.Web.Security;
using System.Data.Entity;
using System.Net;
using GruppG.Data;
using GruppG.Models.db;


namespace GruppG.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        U4Entities ue = new U4Entities();
        Program pr = new Program();
        PersonData personData = new PersonData();
        //Chanel channel = new Chanel();
        PersonData pd = new PersonData();
        private U4Entities db = new U4Entities();

        public ActionResult Admin()
        {
            return View();
        }


        public ActionResult LogIn()
        {
            //Log in

            return View();
        }

        [HttpPost]
        public ActionResult Login(GruppG.Models.db.Person pers)
        {
            using (U4Entities u4 = new U4Entities())
            {
                var user = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password).FirstOrDefault();
                if (user == null)
                {
                    pers.LoginErrorMessage = "Du har angett fel användarnamn eller lösenord";
                    return View("LogIn");
                }
                else
                {
                    Session["Id"] = user.Id;
                    Session["UserName"] = user.UserName.ToString();
                    return RedirectToAction("MyPage", "Login");
                }
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Person pers)
        {
            //Ingen vy
            using (U4Entities newPerson = new U4Entities())
            {
                newPerson.Person.Add(pers);
                newPerson.SaveChanges();
            }
            return View();
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

        
        public ActionResult MyPage()
        {
            //Visitor or admins page
            //var myChannel = db.Chanel.Include(p => p.Name);
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
            
        }

        //public ActionResult PartialViewChannel()
        //{
           
        //    //var myCh = db.Chanel.Include(m => m
        //    //return View(db.Chanel.ToList());
        //}

        public ActionResult UserPage(int id)
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        //public ActionResult PartialViewPerson(int id)
        //{
        //    var pers = pd.GetPersonById(id);
        //    return PartialView();
        //}

        //if (ModelState.IsValid)
        //{
        //Skapar en log in cookie som är persistent. Den försvinner när browsern stängs.
        //FormsAuthentication.SetAuthCookie(model.UserName, false);
        //FormsAuthentication.SetAuthCookie(model.Password, false);
        //pd.CheckUserCreadentials();

        //}

        public ActionResult PartialViewChannel()
        {
            var chan = ue.Chanel.Include(c => c.Name);
            var chan1 = ue.Chanel;
            return View(chan1.ToList());
        }

        //[HttpPost]
        //public ActionResult LoginAdmin(GruppG.Models.db.Person pers)
        //{
        //    using (U4Entities u4 = new U4Entities())
        //    {
        //        var ud = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password).FirstOrDefault();
        //        if (ud == null)
        //        {
        //            pers.LoginErrorMessage = "Du har angett fel användarnamn eller lösenord";
        //            return View("LogIn", pers);
        //        }
        //        else
        //        {
        //            Session["Id"] = ud.Id;
        //            return RedirectToAction("MyPage", "Home");
        //        }
        //    }


        //if (ModelState.IsValid)
        //{
        //Skapar en log in cookie som är persistent. Den försvinner när browsern stängs.
        //FormsAuthentication.SetAuthCookie(model.UserName, false);
        //FormsAuthentication.SetAuthCookie(model.Password, false);
        //pd.CheckUserCreadentials();

        //    }
    }
}

