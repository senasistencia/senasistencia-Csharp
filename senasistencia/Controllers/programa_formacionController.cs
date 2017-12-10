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
    public class programa_formacionController : Controller
    {
        private DBContext db = new DBContext();

        // GET: programa_formacion
        public ActionResult Index()
        {
            return View(db.programa_formacion.ToList());
        }

        // GET: programa_formacion/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programa_formacion programa_formacion = db.programa_formacion.Find(id);
            if (programa_formacion == null)
            {
                return HttpNotFound();
            }
            return View(programa_formacion);
        }

        // GET: programa_formacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: programa_formacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Programa,Nombre,Estado_Programa,FechaDeCreacion_Programa,FechaDeInactivacion_Programa")] programa_formacion programa_formacion)
        {
            if (ModelState.IsValid)
            {
                db.programa_formacion.Add(programa_formacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programa_formacion);
        }

        // GET: programa_formacion/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programa_formacion programa_formacion = db.programa_formacion.Find(id);
            if (programa_formacion == null)
            {
                return HttpNotFound();
            }
            return View(programa_formacion);
        }

        // POST: programa_formacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Programa,Nombre,Estado_Programa,FechaDeCreacion_Programa,FechaDeInactivacion_Programa")] programa_formacion programa_formacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programa_formacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programa_formacion);
        }

        // GET: programa_formacion/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programa_formacion programa_formacion = db.programa_formacion.Find(id);
            if (programa_formacion == null)
            {
                return HttpNotFound();
            }
            return View(programa_formacion);
        }

        // POST: programa_formacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            programa_formacion programa_formacion = db.programa_formacion.Find(id);
            db.programa_formacion.Remove(programa_formacion);
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
