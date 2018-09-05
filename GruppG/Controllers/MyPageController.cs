using GruppG.Data;
using GruppG.Models.db;
using GruppG.Models.ViewModels;
using GruppG.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using System.Net;

namespace GruppG.Controllers
{
    [AuthorizeRoles("User", "Admin")]
    public class MyPageController : Controller
    {
        // GET: MyPage
        
        U4Entities db = new U4Entities();
        Chanel channel = new Chanel();
        FavoriteChannel favchannel = new FavoriteChannel();
        ProgramChannelVM pcViewModel = new ProgramChannelVM();
        ProgramData pd = new ProgramData();
        PersonData pr = new PersonData();
        Person person = new Person();



        //MyPage
        public ActionResult Index(DateTime? date, int? category = null)
        {
            
            var name = User.Identity.Name;
           
            return View(pd.FilterProgramsByDateAndCategoryMyPage(name, date, category));

            }
            

        public ActionResult MyFavoriteChannels()
        {
            var name = User.Identity.Name;
            var id = pr.GetId(name);
            var pers = db.Person.Single(e => e.Id == id);
            var channel = pd.GetChannels();
            pcViewModel.ChannelListVM = channel;
            pcViewModel.Person = pers;

            var favoriteChannel = pd.GetFavoriteChannels(id);
            pcViewModel.FavoriteChannelsVM = favoriteChannel;

            return View(pcViewModel);
        }
       

        //Adds channel to favoritechannel & checks if channel allready exists in favoritechannel
        public ActionResult Add(int? pId, int? cId)
        {
            var p = pId;
            var c = cId;
            
            var favorite = new FavoriteChannel() { Person = p, Chanel = c };
            
            if (pd.CheckFavChanExists(pId,cId) == true)
            {
                TempData["message"] = "Kanalen finns redan som din favorit";
                return RedirectToAction("MyFavoriteChannels", new { @id = pId });
            }
            else if (p == null && c == null)
            {
                TempData["message"] = "Det finns ingen användare eller kanal";
                return ViewBag.Message = ("Det finns ingen användare eller kanal");
            }
            else
            {  
                db.FavoriteChannel.Add(favorite);
                db.SaveChanges();
                return RedirectToAction("MyFavoriteChannels", new { @id = pId });
            }
        }


        //Delete channel from my favoritechannels
        public ActionResult Delete(int? fcid, int? id)
        {
            FavoriteChannel favDelete = db.FavoriteChannel.Find(fcid);
            if (fcid == null && id != null)
            {
                return ViewBag.Message = ("Finns inget att radera...");
            }
            else
            {
                db.FavoriteChannel.Remove(favDelete);
                db.SaveChanges();
                return RedirectToAction("MyFavoriteChannels", new { @id = id });
            }
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
    }
}