using GruppG.Data;
using GruppG.Models.db;
using GruppG.Models.ViewModels;
using GruppG.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    public class MyPageController : Controller
    {
        // GET: MyPage

        U4Entities db = new U4Entities();
        Chanel channel = new Chanel();
        FavoriteChannel favchannel = new FavoriteChannel();
        FavoriteChannel newFavoriteChannel;
        FavoritChannelVM favchannelVM = new FavoritChannelVM();
        FavoritChannelVM finalItem = new FavoritChannelVM();
        ProgramChannelVM pcViewModel = new ProgramChannelVM();
        ProgramData pd = new ProgramData();
        Person person = new Person();

        //[Authorize(Roles = "User")]
        //[Authorize]
        public ActionResult Index(int id, DateTime? date, int? category = null)
        {
            //if (Session["UserName"] != null)     int id, 
            //{
            
            var channel = pd.GetChannels();
                var program = pd.GetPrograms();
                var person = pd.GetPersonById(id);
            //var filter = pd.FilterProgramsByDateAndCategoryMyPage(date);
            //var filter = pd.FilterProgramsByDateAndCategory(date, category);
            var myFav = pd.FilterProgramsByDateAndCategoryMyPage(id, date, category);
            

                finalItem.PersonP = person;
                finalItem.ChannelListVM = channel;
                finalItem.ProgramListVM = program;

                var favoriteChannel = pd.GetFavoriteChannels(id);
                finalItem.FavoriteChannelsVM = favoriteChannel;
                //finalItem.ProgramListVM = filter;

                return View(finalItem);
            }
            //else
            //{
            //    return RedirectToAction("Login", "LogIn");
            //}
           
        //}

        public ActionResult MyFavoriteChannels(int id)
        {
            var pers = db.Person.Single(e => e.Id == id);
            var channel = pd.GetChannels();
            finalItem.ChannelListVM = channel;
            finalItem.PersonP = pers;

            var favoriteChannel = pd.GetFavoriteChannels(id);
            finalItem.FavoriteChannelsVM = favoriteChannel;

            return View(finalItem);

        }
       
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyFavoriteChannels(FavoriteChannel favorite, int fcid, int id, int chan, string action)
        {
            //FavoriteChannel favC, , int channel  , string action
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            else if (action == "Spara")
                //else if (action.Equals("Spara"))
            {
                //Lägg till favoritkanal
                int p = id;
                int c = chan;
                //newFavoriteChannel = new FavoriteChannel() { Person = p, Chanel = c};
                favorite = new FavoriteChannel() { Person = p, Chanel = c };

                var pers = db.Person.Single(e => e.Id == id);
                var ch = db.Chanel.Single(a => a.Id == chan);

                //var n = db.FavoriteChannel.Add(newFavoriteChannel);
                db.FavoriteChannel.Add(favorite);
                
               
                db.SaveChanges();
                return RedirectToAction("Index", new { @id = id });
            }
            else if (action.Equals("Ta bort som favoritkanal"))
            {
                int f = fcid;
                //newFavoriteChannel = new FavoriteChannel() { Id = fc };
                //var favoriteDelete = db.FavoriteChannel.Find(favchannel.Id);
                //var deleteFavorite = db.FavoriteChannel = favorite;
                //newFavoriteChannel = favorite;
                //favchannelVM.FavoriteChannelsVM = pd.GetFavoriteChannels(id, chan);
                //var channelsDelete = favchannelVM.FavoriteChannelsVM.Where(x => x.Chanel != chan);

                //var channelsDelete = db.FavoriteChannel.Single(x => x.Id == f);
                
                //db.FavoriteChannel.Remove(channelsDelete);

                var delete = db.FavoriteChannel.Single(x => x.Id == f);
                db.FavoriteChannel.Remove(delete);

                //db.FavoriteChannel.Remove(removeFavoriteChannel);
                db.SaveChanges();
                
                return RedirectToAction("Index", new { @id = id });
                //Mata ev in , "Index"
                //return RedirectToAction("MyFavoriteChannels", "MyPage", new { @id =favoriteDelete.Id });
                //var favoriteDelete1 = pd.GetFavoriteChannels().SingleOrDefault(i => i.Id == id);
                //favoriteDelete = favchannel;

            }
            return RedirectToAction("MyFavoriteChannels", new { @id = id });
        }

        
        

        //ADD - fungerar halvt (den lägger till flera av samma)
        public ActionResult Add(int? pId, int? cId)
        {
            ViewBag.Message = " ";
            var p = pId;
            var c = cId;
            
            var favorite = new FavoriteChannel() { Person = p, Chanel = c };

            var pers = db.Person.Single(e => e.Id == p);
            var chan = db.Chanel.Single(a => a.Id == c);

            if (pd.CheckFavChanExists(p,c) == true)
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


        //DELETE - FUNGERAR! :)
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


    }
}