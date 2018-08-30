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
        PersonData pd = new PersonData();
        Program pr = new Program();
        Person person = new Person();
        FavoriteChannel favC = new FavoriteChannel();
        Chanel channel = new Chanel();
        FavoritChannelVM viewmodel = new FavoritChannelVM();
        


        // GET: Login (Account?)
        public ActionResult LogIn()
        {
            return View();
        }


        //Nadias test
        [HttpPost]
        public ActionResult LogIn(LoginVM model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                var user = db.Person.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
                //Login-Cookie (försvinner när browsern stängs ner eftersom den inte är persistent).
                
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                //Session["Id"] = user.Id;
                //if(Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") &&
                //    !returnUrl.StartsWith("/\\"))
                //{
                //    return Redirect(returnUrl);
                //}
                //else 
                //{
                //    Session["Id"] = user.Id;
                //    Session["UserName"] = user.UserName.ToString();
                //    //    //return RedirectToAction("Index", "MyPage", new { @id = user.Id });
                //    return RedirectToAction("MinaSidor", "MyPage"/*, new { @id = user.Id }*/);
                //}     
                if (pd.CheckUser(model.UserName, model.Password) && user.Role == 1)
                {
                    //return Redirect(returnUrl); //<-- string ReturnUrl som inparameter
                    //return Redirect(returnUrl, new { id = user.Id });
                    //return RedirectToAction("Index","Admin", new { ReturnUrl = returnUrl, @id = user.Id });
                    return RedirectToAction("Index", "Admin");
                    //return Redirect(returnUrl);
                    //return Redirect("/");
                }

                else if (pd.CheckUser(model.UserName, model.Password) && user.Role == 2)
                {
                    var id = pd.GetId(model.UserName, model.Password);
                    //Session["Id"] = user.Id;
                    //Session["UserName"] = user.UserName.ToString();
                    //return RedirectToAction("Index", "MyPage", new { @id = user.Id });
                    //return Redirect(returnUrl);
                    //return RedirectToAction("Index", "MyPage", new { returnUrl = returnUrl, @id = user.Id });
                    //Session["Id"] = user.Id.ToString();

                    //if (Session["Id"] == null)
                    //    Session["Id"] = user.Id;
                    //To Get it:

                    //if (System.Web.HttpContext.Current.Session["UserID"] != null)
                    //{
                    //    var test = System.Web.HttpContext.Current.Session["UserID"];
                    //}

                    //new { patientId = @Model }
                    //return RedirectToAction("Index", "MyPage", new { @id = user.Id });
                    //return RedirectToAction("Index", "MyPage", new { @id = model.Id });

                    //Skickar inparameter - Men då går det inte att surfa runt bland länkarna...
                    return RedirectToAction("Index", "MyPage"/*, new { @id = id }*/);

                    //FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    //return RedirectToAction("Index", "MyPage");
                }
            }

            else
            {
                //TempData["messageError"] = "Felaktigt användarnamn eller lösenord.";
                ModelState.AddModelError("", "Felaktikt användarnamn eller lösenord.");
            }

                return View();
        }




        //SignOut
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //// POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    FormsAuthentication.SignOut();
        //    //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return RedirectToAction("Index", "Home");
        //}



        //check user account/details
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            //Person person = new Person();
            //var personDetails = db.Person.Where(x => x.Id == userId);
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
            //If modelstate is valid and användaren nonexists
            if (ModelState.IsValid)
            {
                if (pd.CheckUserExists(username)== false)
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

        

        public ActionResult FavoriteChannel()
        {
            var chan = db.Chanel.Include(c => c.Name);
            var chan1 = db.Chanel;
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
            var chan = db.Chanel.Include(c => c.Name);
            var chan1 = db.Chanel;
            return PartialView(chan1.ToList());
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

        //[Authorize]

        //DENNA FUNGERAR TILL MYPAGE (vanlig användare)
        //[HttpPost]
        //public ActionResult LogIn(Person pers)
        //{
        //    using (U4Entities u4 = new U4Entities())
        //    {
        //        var user = u4.Person.Where(x => x.UserName == pers.UserName && x.Password == pers.Password).FirstOrDefault();

        //        if (user == null)
        //        {
        //            ModelState.AddModelError("", "Felaktikt användarnamn eller lösenord.");
        //            //pers.LoginErrorMessage = "Du har angett fel användarnamn eller lösenord";
        //            return View();
        //        }
        //        else
        //        {
        //            Session["Id"] = user.Id;
        //            Session["UserName"] = user.UserName.ToString();
        //            return RedirectToAction("Index", "MyPage", new { @id = user.Id });
        //        }
        //    }
        //}





    }
}

