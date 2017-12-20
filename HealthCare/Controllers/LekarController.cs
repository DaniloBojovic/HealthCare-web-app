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
    public class LekarController : Controller
    {
        private HContext db = new HContext();

        // GET: Lekar
        public ActionResult Index()
        {
            return View(db.Lekari.ToList());
        }

        // GET: Lekar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Lekar lekar = db.Lekari.Find(id);
            Lekar lekar = db.Lekari.Include(l => l.Files).SingleOrDefault(l => l.ID == id);//
            if (lekar == null)
            {
                return HttpNotFound();
            }
            return View(lekar);
        }

        // GET: Lekar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lekar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prezime,Ime,DatumZaposlenja,Email")] Lekar lekar, HttpPostedFileBase upload) //Sklonjen ID - auto..
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)//
                    {
                        var foto = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Foto,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            foto.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        lekar.Files = new List<File> { foto };
                    }
                    db.Lekari.Add(lekar);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(lekar);
        }

        // GET: Lekar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Lekar lekar = db.Lekari.Find(id);
            Lekar lekar = db.Lekari.Include(l => l.Files).SingleOrDefault(l => l.ID == id);//
            if (lekar == null)
            {
                return HttpNotFound();
            }
            return View(lekar);
        }

        // POST: Lekar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lekarZaUpdate = db.Lekari.Find(id);
            if (TryUpdateModel(lekarZaUpdate, "",
                new string[] { "ID", "Prezime", "Ime", "DatumZaposlenja", "Email" }))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (lekarZaUpdate.Files.Any(f => f.FileType == FileType.Foto))
                        {
                            db.Files.Remove(lekarZaUpdate.Files.First(f => f.FileType == FileType.Foto));
                        }
                        var foto = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Foto,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            foto.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        lekarZaUpdate.Files = new List<File> { foto };
                    }
                    db.Entry(lekarZaUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(lekarZaUpdate);
        }
        // GET: Lekar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lekar lekar = db.Lekari.Find(id);
            if (lekar == null)
            {
                return HttpNotFound();
            }
            return View(lekar);
        }

        // POST: Lekar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Lekar lekar = db.Lekari.Find(id);
            Lekar lekar = db.Lekari.Include(p => p.Files).SingleOrDefault(p => p.ID == id);
            File file = db.Files.Include(f => f.Lekar).SingleOrDefault(f => f.LekarID == id);
            db.Lekari.Remove(lekar);
            if (file != null)
            {
                db.Files.Remove(file);
            }
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
