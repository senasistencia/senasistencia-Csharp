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
    public class excusaController : Controller
    {
        private DBContext db = new DBContext();

        // GET: excusa
        public ActionResult Index()
        {
            var excusa = db.excusa.Include(e => e.aprendiz);
            return View(excusa.ToList());
        }

        // GET: excusa/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            excusa excusa = db.excusa.Find(id);
            if (excusa == null)
            {
                return HttpNotFound();
            }
            return View(excusa);
        }

        // GET: excusa/Create
        public ActionResult Create()
        {
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz");
            return View();
        }

        // POST: excusa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Excusa,ID_DocumentoAprendiz,Fecha_Excusa,Periodo_Excusa,Estado_Excusa,FechaDeCreacion_Excusa,FechaDeInactivacion_Excusa")] excusa excusa)
        {
            if (ModelState.IsValid)
            {
                db.excusa.Add(excusa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", excusa.ID_DocumentoAprendiz);
            return View(excusa);
        }

        // GET: excusa/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            excusa excusa = db.excusa.Find(id);
            if (excusa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", excusa.ID_DocumentoAprendiz);
            return View(excusa);
        }

        // POST: excusa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Excusa,ID_DocumentoAprendiz,Fecha_Excusa,Periodo_Excusa,Estado_Excusa,FechaDeCreacion_Excusa,FechaDeInactivacion_Excusa")] excusa excusa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excusa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", excusa.ID_DocumentoAprendiz);
            return View(excusa);
        }

        // GET: excusa/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            excusa excusa = db.excusa.Find(id);
            if (excusa == null)
            {
                return HttpNotFound();
            }
            return View(excusa);
        }

        // POST: excusa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            excusa excusa = db.excusa.Find(id);
            db.excusa.Remove(excusa);
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
