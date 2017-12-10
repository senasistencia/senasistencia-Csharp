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
    public class centro_formacionController : Controller
    {
        private DBContext db = new DBContext();

        // GET: centro_formacion
        public ActionResult Index()
        {
            return View(db.centro_formacion.ToList());
        }

        // GET: centro_formacion/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centro_formacion centro_formacion = db.centro_formacion.Find(id);
            if (centro_formacion == null)
            {
                return HttpNotFound();
            }
            return View(centro_formacion);
        }

        // GET: centro_formacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: centro_formacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Centro,Nombre_Centro,Direccion_Centro,Telefono_Centro,Estado_Centro,FechaDeCreacion_Centro,FechaDeInactivacion_Centro")] centro_formacion centro_formacion)
        {
            if (ModelState.IsValid)
            {
                db.centro_formacion.Add(centro_formacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centro_formacion);
        }

        // GET: centro_formacion/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centro_formacion centro_formacion = db.centro_formacion.Find(id);
            if (centro_formacion == null)
            {
                return HttpNotFound();
            }
            return View(centro_formacion);
        }

        // POST: centro_formacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Centro,Nombre_Centro,Direccion_Centro,Telefono_Centro,Estado_Centro,FechaDeCreacion_Centro,FechaDeInactivacion_Centro")] centro_formacion centro_formacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centro_formacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centro_formacion);
        }

        // GET: centro_formacion/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centro_formacion centro_formacion = db.centro_formacion.Find(id);
            if (centro_formacion == null)
            {
                return HttpNotFound();
            }
            return View(centro_formacion);
        }

        // POST: centro_formacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            centro_formacion centro_formacion = db.centro_formacion.Find(id);
            db.centro_formacion.Remove(centro_formacion);
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
