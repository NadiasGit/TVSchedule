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
    [AuthorizeRoles("Admin")] //<= Ska användas för att inte komma åt sidan om man inte är inloggad
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
            //Lägg till ett felmeddelande/felhantering om program-id saknas
            var progDetails = db.Program.Single(e => e.Id == id);
            ViewBag.Message = pd.PuffName(progDetails.Puff);
            //return RedirectToAction("ProgramDetails", "Home");
            return View(progDetails);
        }


        //Create puff
            //For future tasks...


        //Edit PUFF
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
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return ViewBag.Message=("Något blev fel!");
            }
            else
            {
                var progEdit = db.Program.Single(e => e.Id == id);
                TempData["messageSuccess"] = "Puffen är registrerad.";
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
                //Index -> program i modelstate-view
                //Program som inp. 
            
                Program puffToEdit = db.Program.Find(id);
                //if (puffToEdit == null)
                //{
                //    return HttpNotFound();
                //}

                
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }
                else
            puffToEdit.Puff = 1;
            db.SaveChanges();
            
            //var newPuff = pd.PuffPrograms().Where(p => p.Puff == 1);
            return RedirectToAction("Index");

            
        }        
        

        //Delete puffar
        public ActionResult Delete(int? id)
        {
            Program puffDelete = db.Program.Find(id);
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return ViewBag.Message = ("Finns inget att radera...");
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
            
            //var puff = db.Program.Select(p => p.Puff == 1 );
            //db.Program.Remove(program);
            //db.SaveChanges();
            //var puffList = pd.PuffPrograms().Where(p => p.Puff == 1);
            return RedirectToAction("Index");
        }





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(int id, Program program)
        //{
        //    Program puffToEdit = db.Program.Find(id);
        //    if (puffToEdit == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    else
        //    if (!ModelState.IsValid)
        //    {
        //        return View(program);
        //    }
        //    puffToEdit.Puff = program.Puff;
        //    puffToEdit.Puff = 0;
        //    var puffToRemove = pd.PuffPrograms().Where(i => i.Puff != 1).ToList();


        //    db.SaveChanges();

        //    //var newPuff = pd.PuffPrograms().Where(p => p.Puff == program.Puff);
        //    return RedirectToAction("Index");


        //}



    }
}