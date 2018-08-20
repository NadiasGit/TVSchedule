using GruppG.Data;
using GruppG.Models.db;
using GruppG.Models.ViewModels;
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

        public ActionResult Index(int id)
        {
            var channel = pd.GetChannels();
            var program = pd.GetPrograms();
            var person = pd.GetPersonById(id);

            finalItem.PersonP = person;
            finalItem.ChannelListVM = channel;
            finalItem.ProgramListVM = program;


            var favoriteChannel = pd.GetFavoriteChannels(id);
            finalItem.FavoriteChannelsVM = favoriteChannel;

            return View(finalItem);
        }

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
            else if (action.Equals("Spara"))
            {
                //Lägg till favoritkanal
                int p = id;
                int c = chan;
                newFavoriteChannel = new FavoriteChannel() { Person = p, Chanel = c};

                var pers = db.Person.Single(e => e.Id == id);
                var ch = db.Chanel.Single(a => a.Id == chan);

                var n = db.FavoriteChannel.Add(newFavoriteChannel);

               
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

                var channelsDelete = db.FavoriteChannel.Single(x => x.Id == f);

                db.FavoriteChannel.Remove(channelsDelete);

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

        





        //Ta bort?
        public ActionResult MyFavotieChannel(int id)
        {
            var persEdit = db.Person.Single(e => e.Id == id);
            return View(persEdit);
        }

        [HttpPost]
        public ActionResult MyFavotieChannel(FavoritChannelVM fchannel)
        {
            favchannel = new Models.db.FavoriteChannel()
            {
                Person = fchannel.Person,
                Chanel = fchannel.Chanel
            };

            channel = new Chanel()
            {
                Id = fchannel.Chanel,
                Name = fchannel.ChannelName,
            };

            person = new Person()
            {
                FirstName = fchannel.FirstName,
                LastName = fchannel.LastName,
                UserName = fchannel.UserName,
                Password = fchannel.Password
            };


            using (U4Entities myChannel = new U4Entities())
            {
                myChannel.FavoriteChannel.Add(favchannel);
                myChannel.SaveChanges();
            }
            return View();
        }

    }
}