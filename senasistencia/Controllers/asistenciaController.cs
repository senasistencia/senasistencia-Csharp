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
    public class asistenciaController : Controller
    {
        private DBContext db = new DBContext();

        // GET: asistencias
        public ActionResult Index()
        {
            var asistencia = db.asistencia.Include(a => a.aprendiz);
            return View(asistencia.ToList());
        }

        // GET: asistencias/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: asistencias/Create
        public ActionResult Create()
        {
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz");
            return View();
        }

        // POST: asistencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Asistencia,ID_DocumentoAprendiz,Descripcion_Asistencia,Fecha_Asistencia,Estado_Asistencia,FechaDeCreacion_Asistencia,FechaDeInactivacion_Asistencia")] asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.asistencia.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", asistencia.ID_DocumentoAprendiz);
            return View(asistencia);
        }

        // GET: asistencias/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", asistencia.ID_DocumentoAprendiz);
            return View(asistencia);
        }

        // POST: asistencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Asistencia,ID_DocumentoAprendiz,Descripcion_Asistencia,Fecha_Asistencia,Estado_Asistencia,FechaDeCreacion_Asistencia,FechaDeInactivacion_Asistencia")] asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", asistencia.ID_DocumentoAprendiz);
            return View(asistencia);
        }

        // GET: asistencias/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            asistencia asistencia = db.asistencia.Find(id);
            db.asistencia.Remove(asistencia);
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
