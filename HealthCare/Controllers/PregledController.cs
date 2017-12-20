using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthCare.DAL;
using HealthCare.Models;

namespace HealthCare.Controllers
{
    public class PregledController : Controller
    {
        private HContext db = new HContext();

        // GET: Pregled
        public ActionResult Index()
        {
            return View(db.Pregledi.ToList());
        }

        // GET: Pregled/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregled pregled = db.Pregledi.Find(id);
            if (pregled == null)
            {
                return HttpNotFound();
            }
            return View(pregled);
        }

        // GET: Pregled/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pregled/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PregledID,Naziv,Opis")] Pregled pregled)
        {
            if (ModelState.IsValid)
            {
                db.Pregledi.Add(pregled);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pregled);
        }

        // GET: Pregled/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregled pregled = db.Pregledi.Find(id);
            if (pregled == null)
            {
                return HttpNotFound();
            }
            return View(pregled);
        }

        // POST: Pregled/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PregledID,Naziv,Opis")] Pregled pregled)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregled).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pregled);
        }

        // GET: Pregled/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregled pregled = db.Pregledi.Find(id);
            if (pregled == null)
            {
                return HttpNotFound();
            }
            return View(pregled);
        }

        // POST: Pregled/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pregled pregled = db.Pregledi.Find(id);
            db.Pregledi.Remove(pregled);
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
