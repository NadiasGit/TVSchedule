using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GruppG.Models.db;

namespace GruppG.Controllers
{
    //Används inte

    //Skapad med hjälp av entity-framework
    public class ProgramsC : Controller
    {
        private U4Entities db = new U4Entities();

        // GET: ProgramsC
        public ActionResult Index()
        {
            var program = db.Program.Include(p => p.Category1).Include(p => p.Chanel1);
            return View(program.ToList());
        }

        // GET: ProgramsC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Program.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: ProgramsC/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Category, "Id", "Name");
            ViewBag.Chanel = new SelectList(db.Chanel, "Id", "Name");
            return View();
        }

        // POST: ProgramsC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titel,Description,Chanel,Category,Starttime,Endtime,Puff,Programstart")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Program.Add(program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(db.Category, "Id", "Name", program.Category);
            ViewBag.Chanel = new SelectList(db.Chanel, "Id", "Name", program.Chanel);
            return View(program);
        }

        // GET: ProgramsC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Program.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.Category, "Id", "Name", program.Category);
            ViewBag.Chanel = new SelectList(db.Chanel, "Id", "Name", program.Chanel);
            return View(program);
        }

        // POST: ProgramsC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titel,Description,Chanel,Category,Starttime,Endtime,Puff,Programstart")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Category, "Id", "Name", program.Category);
            ViewBag.Chanel = new SelectList(db.Chanel, "Id", "Name", program.Chanel);
            return View(program);
        }

        // GET: ProgramsC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.Program.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: ProgramsC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = db.Program.Find(id);
            db.Program.Remove(program);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
