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

        U4Entities u4 = new U4Entities();
        Chanel channel = new Chanel();
        FavoriteChannel favchannel = new FavoriteChannel();
        FavoritChannelVM favchannelVM = new FavoritChannelVM();
        FavoritChannelVM finalItem = new FavoritChannelVM();
        ProgramData pd = new ProgramData();
        Person person = new Person();

        public ActionResult Index(int id)
        {
            //var person = u4.Person;
            //return View(person);
            var pers = u4.Person.Single(e => e.Id == id);
            return View(pers);
        }

        public ActionResult MyFavoriteChannels(int id)
        {
            var pers = u4.Person.Single(e => e.Id == id);
            var channel = pd.GetChannels();
            finalItem.ChannelListVM = channel;
            finalItem.PersonP = pers;
            return View(finalItem);

        }

        public ActionResult MyFavotieChannel(int id)
        {
            var persEdit = u4.Person.Single(e => e.Id == id);
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