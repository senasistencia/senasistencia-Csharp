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
    public class sedeController : Controller
    {
        private DBContext db = new DBContext();

        // GET: sede
        public ActionResult Index()
        {
            var sede = db.sede.Include(s => s.centro_formacion);
            return View(sede.ToList());
        }

        // GET: sede/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sede sede = db.sede.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // GET: sede/Create
        public ActionResult Create()
        {
            ViewBag.ID_Centro = new SelectList(db.centro_formacion, "ID_Centro", "Nombre_Centro");
            return View();
        }

        // POST: sede/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Sede,Nombre_Sede,Direccion_Sede,Telefono,ID_Centro,Estado_sede,FechaDeCreacion_Sede,FechaDeInactivacion_Sede")] sede sede)
        {
            if (ModelState.IsValid)
            {
                db.sede.Add(sede);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Centro = new SelectList(db.centro_formacion, "ID_Centro", "Nombre_Centro", sede.ID_Centro);
            return View(sede);
        }

        // GET: sede/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sede sede = db.sede.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Centro = new SelectList(db.centro_formacion, "ID_Centro", "Nombre_Centro", sede.ID_Centro);
            return View(sede);
        }

        // POST: sede/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Sede,Nombre_Sede,Direccion_Sede,Telefono,ID_Centro,Estado_sede,FechaDeCreacion_Sede,FechaDeInactivacion_Sede")] sede sede)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sede).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Centro = new SelectList(db.centro_formacion, "ID_Centro", "Nombre_Centro", sede.ID_Centro);
            return View(sede);
        }

        // GET: sede/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sede sede = db.sede.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // POST: sede/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            sede sede = db.sede.Find(id);
            db.sede.Remove(sede);
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
