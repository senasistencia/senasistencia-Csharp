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
    public class trimestreController : Controller
    {
        private DBContext db = new DBContext();

        // GET: trimestre
        public ActionResult Index()
        {
            return View(db.trimestre.ToList());
        }

        // GET: trimestre/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trimestre trimestre = db.trimestre.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // GET: trimestre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: trimestre/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Trimestre,Num_Trimestre,Estado_Trimestre,FechaDeCreacion_Trimestre,FechaDeInactivacion_Trimestre")] trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                db.trimestre.Add(trimestre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trimestre);
        }

        // GET: trimestre/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trimestre trimestre = db.trimestre.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // POST: trimestre/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Trimestre,Num_Trimestre,Estado_Trimestre,FechaDeCreacion_Trimestre,FechaDeInactivacion_Trimestre")] trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimestre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trimestre);
        }

        // GET: trimestre/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trimestre trimestre = db.trimestre.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // POST: trimestre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            trimestre trimestre = db.trimestre.Find(id);
            db.trimestre.Remove(trimestre);
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
