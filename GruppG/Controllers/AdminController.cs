using GruppG.Data;
using GruppG.Models.db;
using GruppG.Models.ViewModels;
using GruppG.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Controllers
{
    [AuthorizeRoles("Admin")] //<= Only admins will have access to these views/functions.
    public class AdminController : Controller
    {
        private ProgramData pd = new ProgramData();
        ProgramChannelVM viewModel = new ProgramChannelVM();
        U4Entities db = new U4Entities();
        Program program;
  

        // GET: Admin
        public ActionResult Index(DateTime? date, int? id = null)
        {
            ViewBag.Message = ("Inget på TV idag :( ... ");

            return View(pd.FilterProgramsByDateAndChannel(date,id));
        }


        //Program Details
        public ActionResult ProgramDetails(int id)
        {
            var progDetails = db.Program.Single(e => e.Id == id);
            ViewBag.Message = pd.PuffName(progDetails.Puff);
            return View(progDetails);  
        }


        //Add PUFF
        public ActionResult Edit(int? id)
        {
            ViewBag.Message = "Max antal puffar är 3!";
            program = db.Program.Find(id);
            if (pd.CountPuff() == true)
            {
                TempData["message"] = "Det maximala antalet puffar är 3";
                return RedirectToAction("Index");
            }
            else if (id == null)
            {
                return ViewBag.Message=("Något blev fel!");
            }
            else   
            {
                var progEdit = db.Program.Single(e => e.Id == id);
                ViewBag.Message = pd.PuffName(progEdit.Puff);
                return View(progEdit);
            }
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            Program puffToEdit = db.Program.Find(id);
            if (puffToEdit == null)
            {
                return HttpNotFound();
            }
            else if (id == 0)
            {
                TempData["message"] = "Puffen är ej registrerad.";
                return RedirectToAction("Index");
            }

            else
            {
                puffToEdit.Puff = 1;
                db.SaveChanges();
                TempData["messageSuccess"] = "Puffen är registrerad.";
                return RedirectToAction("Index");
            }

    }        
        

        //Delete PUFF
        public ActionResult Delete(int? id)
        {
            Program puffDelete = db.Program.Find(id);
            if (id == null)
            {
                return ViewBag.Message = ("Finns inget att radera.");
            }
            else
            {
                return View(puffDelete);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program programToRemove = db.Program.Find(id);

            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else

            programToRemove.Puff = 0;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

    }
}