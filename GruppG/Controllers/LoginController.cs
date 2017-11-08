using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        U4Entities ue = new U4Entities();
        Program pr = new Program();

        public ActionResult Admin()
        {
            return View();
        }


        public ActionResult LogIn()
        {
            //Log in

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

        [HttpPost]
        public ActionResult Login(GruppG.Models.db.Person pers)
        {
            using (U4Entities u4 = new U4Entities())
            {
                var ud = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password).FirstOrDefault();
                if (ud == null)
                {
                    //pers.LoginErrorMessage = "Du har angett fel användarnamn eller lösenord";
                    return View("LogIn", pers);
                }
                else
                {
                    Session["Id"] = ud.Id;
                    return RedirectToAction("MyPage", "Home");
                }
            }


            //if (ModelState.IsValid)
            //{
            //Skapar en log in cookie som är persistent. Den försvinner när browsern stängs.
            //FormsAuthentication.SetAuthCookie(model.UserName, false);
            //FormsAuthentication.SetAuthCookie(model.Password, false);
            //pd.CheckUserCreadentials();

            //}

            //public ActionResult LogInAdmin()
            //{
            //    //Log in to admin

            //    return View();
            //}

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
}
