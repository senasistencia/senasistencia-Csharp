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
    public class ambiente_formacionController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ambiente_formacion
        public ActionResult Index()
        {
            var ambiente_formacion = db.ambiente_formacion.Include(a => a.sede);
            return View(ambiente_formacion.ToList());
        }

        // GET: ambiente_formacion/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambiente_formacion ambiente_formacion = db.ambiente_formacion.Find(id);
            if (ambiente_formacion == null)
            {
                return HttpNotFound();
            }
            return View(ambiente_formacion);
        }

        // GET: ambiente_formacion/Create
        public ActionResult Create()
        {
            ViewBag.ID_Sede = new SelectList(db.sede, "ID_Sede", "Nombre_Sede");
            return View();
        }

        // POST: ambiente_formacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Ambiente,Num_Ambiente,ID_Sede,Estado_Ambiente,FechaDeCreacion_Ambiente,FechaDeInactivacion_Ambiente")] ambiente_formacion ambiente_formacion)
        {
            if (ModelState.IsValid)
            {
                db.ambiente_formacion.Add(ambiente_formacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Sede = new SelectList(db.sede, "ID_Sede", "Nombre_Sede", ambiente_formacion.ID_Sede);
            return View(ambiente_formacion);
        }

        // GET: ambiente_formacion/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambiente_formacion ambiente_formacion = db.ambiente_formacion.Find(id);
            if (ambiente_formacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Sede = new SelectList(db.sede, "ID_Sede", "Nombre_Sede", ambiente_formacion.ID_Sede);
            return View(ambiente_formacion);
        }

        // POST: ambiente_formacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ambiente,Num_Ambiente,ID_Sede,Estado_Ambiente,FechaDeCreacion_Ambiente,FechaDeInactivacion_Ambiente")] ambiente_formacion ambiente_formacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambiente_formacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Sede = new SelectList(db.sede, "ID_Sede", "Nombre_Sede", ambiente_formacion.ID_Sede);
            return View(ambiente_formacion);
        }

        // GET: ambiente_formacion/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambiente_formacion ambiente_formacion = db.ambiente_formacion.Find(id);
            if (ambiente_formacion == null)
            {
                return HttpNotFound();
            }
            return View(ambiente_formacion);
        }

        // POST: ambiente_formacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ambiente_formacion ambiente_formacion = db.ambiente_formacion.Find(id);
            db.ambiente_formacion.Remove(ambiente_formacion);
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
