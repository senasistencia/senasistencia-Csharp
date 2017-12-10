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
    public class fichaController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ficha
        public ActionResult Index()
        {
            var ficha = db.ficha.Include(f => f.ambiente_formacion).Include(f => f.jornada).Include(f => f.programa_formacion).Include(f => f.trimestre);
            return View(ficha.ToList());
        }

        // GET: ficha/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ficha ficha = db.ficha.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            return View(ficha);
        }

        // GET: ficha/Create
        public ActionResult Create()
        {
            ViewBag.ID_Ambiente = new SelectList(db.ambiente_formacion, "ID_Ambiente", "ID_Ambiente");
            ViewBag.ID_Jornada = new SelectList(db.jornada, "ID_Jornada", "Descripcion_Jornada");
            ViewBag.ID_Programa = new SelectList(db.programa_formacion, "ID_Programa", "Nombre");
            ViewBag.ID_Trimestre = new SelectList(db.trimestre, "ID_Trimestre", "ID_Trimestre");
            return View();
        }

        // POST: ficha/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Ficha,Num_Ficha,ID_Ambiente,ID_Trimestre,ID_Programa,ID_Jornada,Estado,FechaDeCreacion_Ficha,FechaDeInactivacion_Ficha")] ficha ficha)
        {
            if (ModelState.IsValid)
            {
                db.ficha.Add(ficha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Ambiente = new SelectList(db.ambiente_formacion, "ID_Ambiente", "ID_Ambiente", ficha.ID_Ambiente);
            ViewBag.ID_Jornada = new SelectList(db.jornada, "ID_Jornada", "Descripcion_Jornada", ficha.ID_Jornada);
            ViewBag.ID_Programa = new SelectList(db.programa_formacion, "ID_Programa", "Nombre", ficha.ID_Programa);
            ViewBag.ID_Trimestre = new SelectList(db.trimestre, "ID_Trimestre", "ID_Trimestre", ficha.ID_Trimestre);
            return View(ficha);
        }

        // GET: ficha/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ficha ficha = db.ficha.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Ambiente = new SelectList(db.ambiente_formacion, "ID_Ambiente", "ID_Ambiente", ficha.ID_Ambiente);
            ViewBag.ID_Jornada = new SelectList(db.jornada, "ID_Jornada", "Descripcion_Jornada", ficha.ID_Jornada);
            ViewBag.ID_Programa = new SelectList(db.programa_formacion, "ID_Programa", "Nombre", ficha.ID_Programa);
            ViewBag.ID_Trimestre = new SelectList(db.trimestre, "ID_Trimestre", "ID_Trimestre", ficha.ID_Trimestre);
            return View(ficha);
        }

        // POST: ficha/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ficha,Num_Ficha,ID_Ambiente,ID_Trimestre,ID_Programa,ID_Jornada,Estado,FechaDeCreacion_Ficha,FechaDeInactivacion_Ficha")] ficha ficha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ficha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Ambiente = new SelectList(db.ambiente_formacion, "ID_Ambiente", "ID_Ambiente", ficha.ID_Ambiente);
            ViewBag.ID_Jornada = new SelectList(db.jornada, "ID_Jornada", "Descripcion_Jornada", ficha.ID_Jornada);
            ViewBag.ID_Programa = new SelectList(db.programa_formacion, "ID_Programa", "Nombre", ficha.ID_Programa);
            ViewBag.ID_Trimestre = new SelectList(db.trimestre, "ID_Trimestre", "ID_Trimestre", ficha.ID_Trimestre);
            return View(ficha);
        }

        // GET: ficha/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ficha ficha = db.ficha.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            return View(ficha);
        }

        // POST: ficha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ficha ficha = db.ficha.Find(id);
            db.ficha.Remove(ficha);
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
