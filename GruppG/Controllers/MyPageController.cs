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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var favoriteDelete =  db.FavoriteChannel.Find(id);
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            else
            {
                db.FavoriteChannel.Remove(favoriteDelete);
                db.SaveChanges();

                //Mata ev in , "Index"
                return RedirectToAction("MyFavoriteChannels", "MyPage", new { @id =favoriteDelete.Person });
            }
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