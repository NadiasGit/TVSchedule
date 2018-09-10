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
        U4Entities db = new U4Entities();
        PersonData pr = new PersonData();
        Person person = new Person();    
        
        // GET: Login
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginVM model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                var user = db.Person.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
                //Login-Cookie
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                 
                if (pr.CheckUser(model.UserName, model.Password) && user.Role == 1)
                {
                    var id = pr.GetId(model.UserName, model.Password);
                   
                    return RedirectToAction("Index", "Admin");
                }

                else if (pr.CheckUser(model.UserName, model.Password) && user.Role == 2)
                {
                    var id = pr.GetId(model.UserName, model.Password);
                    
                    return RedirectToAction("Index", "MyPage");   
                }
            }

            else
            {
                //TempData["messageError"] = "Felaktigt användarnamn eller lösenord.";
                ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord.");
            }

                return View();
        }




        //SignOut
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        //Check user account/details
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            return View(person);
        }

        //Register new user-account
        public ActionResult Register()
        {     
            return View();
        }

        [HttpPost]
        public ActionResult Register(Person pers)
        {
            var username = pers.UserName;
            //If modelstate is valid and the user nonexists
            if (ModelState.IsValid)
            {
                if (pr.CheckUserExists(username)== false)
                {
                    db.Person.Add(pers);
                    db.SaveChanges();
                    TempData["message"] = "Registreringen lyckades";
                    return RedirectToAction("Login");   
                } 
                else
                {
                    TempData["message"] = "Användaren finns redan";
                    ModelState.Clear();
                    return View();
                }
            }
            
            ModelState.Clear();
            return View();
        }

        




    }
}

