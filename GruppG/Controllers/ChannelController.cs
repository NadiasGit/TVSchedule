using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    public class ChannelController : Controller
    {
        U4Entities db = new U4Entities();

        // GET: Channel
        public ActionResult Channels()
        {
            var channels = db.Chanel;
            return View(channels);
        }
    }
}