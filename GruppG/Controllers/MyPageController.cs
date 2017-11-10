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
        Person person = new Person();

        public ActionResult Index()
        {
            var prog = u4.Person;
            return View(prog.ToList());
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