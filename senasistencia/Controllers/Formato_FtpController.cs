using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using senasistencia.Models;

namespace senasistencia.Controllers
{
    public class Formato_FtpController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Formato_Ftp
        public ActionResult Index()
        {
            var formato_Ftp = db.Formato_Ftp.Include(f => f.asistencia);
            return View(formato_Ftp.ToList());
        }

        // GET: Formato_Ftp/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato_Ftp formato_Ftp = db.Formato_Ftp.Find(id);
            if (formato_Ftp == null)
            {
                return HttpNotFound();
            }
            return View(formato_Ftp);
        }

        // GET: Formato_Ftp/Create
        public ActionResult Create()
        {
            ViewBag.ID_Asistencia = new SelectList(db.asistencia, "ID_Asistencia", "ID_Asistencia");
            return View();
        }

        // POST: Formato_Ftp/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_formato,Nombre_Formato,Url_Ftp,ID_Asistencia,Estado_Formato,FechaDeCreacion_Formato,FechaDeInactivacion_Formato")] Formato_Ftp formato_Ftp)
        {
            if (ModelState.IsValid)
            {
                db.Formato_Ftp.Add(formato_Ftp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Asistencia = new SelectList(db.asistencia, "ID_Asistencia", "ID_Asistencia", formato_Ftp.ID_Asistencia);
            return View(formato_Ftp);
        }

        // GET: Formato_Ftp/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato_Ftp formato_Ftp = db.Formato_Ftp.Find(id);
            if (formato_Ftp == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Asistencia = new SelectList(db.asistencia, "ID_Asistencia", "ID_Asistencia", formato_Ftp.ID_Asistencia);
            return View(formato_Ftp);
        }

        // POST: Formato_Ftp/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_formato,Nombre_Formato,Url_Ftp,ID_Asistencia,Estado_Formato,FechaDeCreacion_Formato,FechaDeInactivacion_Formato")] Formato_Ftp formato_Ftp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formato_Ftp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Asistencia = new SelectList(db.asistencia, "ID_Asistencia", "ID_Asistencia", formato_Ftp.ID_Asistencia);
            return View(formato_Ftp);
        }

        // GET: Formato_Ftp/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato_Ftp formato_Ftp = db.Formato_Ftp.Find(id);
            if (formato_Ftp == null)
            {
                return HttpNotFound();
            }
            return View(formato_Ftp);
        }

        // POST: Formato_Ftp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Formato_Ftp formato_Ftp = db.Formato_Ftp.Find(id);
            db.Formato_Ftp.Remove(formato_Ftp);
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
