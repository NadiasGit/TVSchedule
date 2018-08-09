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
using Microsoft.AspNet.Identity;

namespace GruppG.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        U4Entities ue = new U4Entities();
        Program pr = new Program();
        Person person = new Person();
        PersonData personData = new PersonData();
        //Chanel channel = new Chanel();
        PersonData pd = new PersonData();
        FavoriteChannel favC = new FavoriteChannel();
        Chanel channel = new Chanel();
        private U4Entities db = new U4Entities();

        


        public ActionResult LogIn()
        {
            //Log in

            return View();
        }

        //[HttpPost]
        //public ActionResult LogIn(LoginVM model/*, string ReturnUrl*/)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ////Skapar en log in cookie som är persistent. Den försvinner när browsern stängs.
        //        //FormsAuthentication.SetAuthCookie(model.UserName, false);
        //        ////FormsAuthentication.SetAuthCookie(model.Password, false);
        //        //return Redirect(ReturnUrl);


        //    }

        //    return View();
        //}



        [HttpPost]
        public ActionResult LogIn(Person pers)
        {
            using (U4Entities u4 = new U4Entities())
            {
                var user = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password).FirstOrDefault();
                if (user == null)
                {
                    pers.LoginErrorMessage = "Du har angett fel användarnamn eller lösenord";
                    return View();
                }
                else
                {
                    Session["Id"] = user.Id;
                    Session["UserName"] = user.UserName.ToString();
                    return RedirectToAction("Index", "MyPage", new { @id = user.Id });
                }
            }
        }


        public ActionResult LogInAdmin()
        {
            //Log in

            return View();
        }

        [HttpPost]
        public ActionResult LogInAdmin(LoginVM pers)
        {
            using (U4Entities u4 = new U4Entities())
            {
                var user = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password && pers.Role ==1).FirstOrDefault();

                if(person.Role == 2)
                {
                    pers.LoginErrorMessage = "Du är ej behörig för denna sida";
                    return View("LogInAdmin");
                }
                else if (user == null)
                {
                    pers.LoginErrorMessage = "Du har angett fel användarnamn eller lösenord";
                    return View("LogInAdmin");
                }
                else
                {
                    Session["Id"] = user.Id;
                    Session["UserName"] = user.UserName.ToString();
                    //var p = ue.Person.Where(per => per.Id == user.Id);
                    return RedirectToAction("MyPage", "Login");
                }
            }
        }
        //chack user account/details
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            //Person person = new Person();
            //var personDetails = db.Person.Where(x => x.Id == userId);
            return View(person);
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

        

        public ActionResult FavoriteChannel()
        {
            var chan = ue.Chanel.Include(c => c.Name);
            var chan1 = ue.Chanel;
            return PartialView(chan1.ToList());
        }

        


        //[Authorize]
        public ActionResult MyPage(int id)
        {
            var pers = db.Person.Single(e => e.Id == id);
            return View(pers);
        }

        public ActionResult Userspage(int id)
        {
            var progEdit = db.Person.Single(e => e.Id == id);
            return View(progEdit);
        }
        
        
        public ActionResult PartialViewChannels()
        {
            var chan = ue.Chanel.Include(c => c.Name);
            var chan1 = ue.Chanel;
            return PartialView(chan1.ToList());
        }


        


        
    }
}

