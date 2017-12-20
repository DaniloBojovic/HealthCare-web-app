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
    public class PacijentController : Controller
    {
        private HContext db = new HContext();

        // GET: Pacijent
        public ActionResult Index(string pretragaPrez)
        {
            var pacijenti = from p in db.Pacijenti select p;

            if (!String.IsNullOrEmpty(pretragaPrez))
            {
                pacijenti = pacijenti.Where
                    (p => p.Prezime.ToUpper().Contains(pretragaPrez.ToUpper()) || p.Ime.ToUpper().Contains(pretragaPrez.ToUpper()));
            }

            return View(pacijenti.ToList());
        }

        // GET: Pacijent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pacijent pacijent = db.Pacijenti.Find(id);
            Pacijent pacijent = db.Pacijenti.Include(p => p.Files).SingleOrDefault(p => p.ID == id);
            if (pacijent == null)
            {
                return HttpNotFound();
            }
            return View(pacijent);
        }

        // GET: Pacijent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacijent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prezime,Ime,DatumRegistracije,Firma")] Pacijent pacijent, HttpPostedFileBase upload) //Sklonjen ID - automatski se unosi.. Dodata param. upload..
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0) //ContentLenght provera da nije empty file
                    {
                        var dokument = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Dokument,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            dokument.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        pacijent.Files = new List<File> { dokument }; //Dodaje u Files kolekciju u pac.
                    }
                    db.Pacijenti.Add(pacijent);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(pacijent);
        }

        // GET: Pacijent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacijent pacijent = db.Pacijenti.Include(p => p.Files).SingleOrDefault(p => p.ID == id);
            if (pacijent == null)
            {
                return HttpNotFound();
            }
            return View(pacijent);
        }

        // POST: Pacijent/Edit/5
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
            var pacijentZaUpdate = db.Pacijenti.Find(id);
            if (TryUpdateModel(pacijentZaUpdate, "",
                new string[] { "ID", "Prezime", "Ime", "DatumRegistracije", "Firma" }))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (pacijentZaUpdate.Files.Any(f => f.FileType == FileType.Dokument))
                        {
                            db.Files.Remove(pacijentZaUpdate.Files.First(f => f.FileType == FileType.Dokument));
                        }
                        var avatar = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Dokument,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        pacijentZaUpdate.Files = new List<File> { avatar };
                    }
                    db.Entry(pacijentZaUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(pacijentZaUpdate);
        }
        // GET: Pacijent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacijent pacijent = db.Pacijenti.Find(id);
            if (pacijent == null)
            {
                return HttpNotFound();
            }
            return View(pacijent);
        }

        // POST: Pacijent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Pacijent pacijent = db.Pacijenti.Find(id);
            Pacijent pacijent = db.Pacijenti.Include(p => p.Files).SingleOrDefault(p => p.ID == id);            
            File file = db.Files.Include(f => f.Pacijent).SingleOrDefault(f => f.PacijentID == id);
            db.Pacijenti.Remove(pacijent);
            if (file != null)
            {
                db.Files.Remove(file);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DownloadFileSposoban()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "Izvestaj Sposoban.pdf");
            string fileName = "Izvestaj Sposoban.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult DownloadFileNesposoban()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "Izvestaj Nesposoban.pdf");
            string fileName = "Izvestaj Nesposoban.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
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
