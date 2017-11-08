using GruppG.Data;
using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    public class PersonController : Controller
    {
        PersonData pd = new PersonData();
        private U4Entities db = new U4Entities();

        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyPage()
        {
            //Visitor or admins page
            //var myChannel = db.Chanel.Include(p => p.Name);
            return View(db.Chanel.ToList());
        }

        public ActionResult PartialViewPerson(int id)
        {
            var pers = pd.GetPersonById(id);
            return PartialView();
        }
    }
}