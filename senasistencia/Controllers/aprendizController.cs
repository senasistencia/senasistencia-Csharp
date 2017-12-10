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
    public class aprendizController : Controller
    {
        private DBContext db = new DBContext();

        // GET: aprendizs
        public ActionResult Index()
        {
            var aprendiz = db.aprendiz.Include(a => a.ficha).Include(a => a.tipo_documento);
            return View(aprendiz.ToList());
        }

        // GET: aprendizs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aprendiz aprendiz = db.aprendiz.Find(id);
            if (aprendiz == null)
            {
                return HttpNotFound();
            }
            return View(aprendiz);
        }

        // GET: aprendizs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Ficha = new SelectList(db.ficha, "ID_Ficha", "ID_Ficha");
            ViewBag.ID_Tipo_Documento = new SelectList(db.tipo_documento, "ID_Tipo_Documento", "Nombre_TipoDeDocumento");
            return View();
        }

        // POST: aprendizs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DocumentoAprendiz,ID_Tipo_Documento,Nombre_Aprendiz,Apellido_Aprendiiz,Correo_Aprendiz,Telefono_Aprendiz,ID_Ficha,Estado_Aprendiz,FechaDeCreacion_Aprendiz,FechaDeInactivacion_Aprendiz")] aprendiz aprendiz)
        {
            if (ModelState.IsValid)
            {
                db.aprendiz.Add(aprendiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Ficha = new SelectList(db.ficha, "ID_Ficha", "ID_Ficha", aprendiz.ID_Ficha);
            ViewBag.ID_Tipo_Documento = new SelectList(db.tipo_documento, "ID_Tipo_Documento", "Nombre_TipoDeDocumento", aprendiz.ID_Tipo_Documento);
            return View(aprendiz);
        }

        // GET: aprendizs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aprendiz aprendiz = db.aprendiz.Find(id);
            if (aprendiz == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Ficha = new SelectList(db.ficha, "ID_Ficha", "ID_Ficha", aprendiz.ID_Ficha);
            ViewBag.ID_Tipo_Documento = new SelectList(db.tipo_documento, "ID_Tipo_Documento", "Nombre_TipoDeDocumento", aprendiz.ID_Tipo_Documento);
            return View(aprendiz);
        }

        // POST: aprendizs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DocumentoAprendiz,ID_Tipo_Documento,Nombre_Aprendiz,Apellido_Aprendiiz,Correo_Aprendiz,Telefono_Aprendiz,ID_Ficha,Estado_Aprendiz,FechaDeCreacion_Aprendiz,FechaDeInactivacion_Aprendiz")] aprendiz aprendiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aprendiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Ficha = new SelectList(db.ficha, "ID_Ficha", "ID_Ficha", aprendiz.ID_Ficha);
            ViewBag.ID_Tipo_Documento = new SelectList(db.tipo_documento, "ID_Tipo_Documento", "Nombre_TipoDeDocumento", aprendiz.ID_Tipo_Documento);
            return View(aprendiz);
        }

        // GET: aprendizs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aprendiz aprendiz = db.aprendiz.Find(id);
            if (aprendiz == null)
            {
                return HttpNotFound();
            }
            return View(aprendiz);
        }

        // POST: aprendizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            aprendiz aprendiz = db.aprendiz.Find(id);
            db.aprendiz.Remove(aprendiz);
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
