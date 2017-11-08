using GruppG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    public class PersonController : Controller
    {
        ProgramData pd = new ProgramData(); 

        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPerson(int id)
        {
            var pers = pd.GetPersonById(id);
            return View();
        }
    }
}