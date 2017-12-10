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
    public class tipo_documentoController : Controller
    {
        private DBContext db = new DBContext();

        // GET: tipo_documento
        public ActionResult Index()
        {
            return View(db.tipo_documento.ToList());
        }

        // GET: tipo_documento/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_documento tipo_documento = db.tipo_documento.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // GET: tipo_documento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_documento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Tipo_Documento,Nombre_TipoDeDocumento,Nomenclatura_TipoDeDocumento,Estado_TipoDeDocumento,FechaDeCreacion_Doc,FechaDeInactivacion_Doc")] tipo_documento tipo_documento)
        {
            if (ModelState.IsValid)
            {
                db.tipo_documento.Add(tipo_documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_documento);
        }

        // GET: tipo_documento/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_documento tipo_documento = db.tipo_documento.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // POST: tipo_documento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Tipo_Documento,Nombre_TipoDeDocumento,Nomenclatura_TipoDeDocumento,Estado_TipoDeDocumento,FechaDeCreacion_Doc,FechaDeInactivacion_Doc")] tipo_documento tipo_documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_documento);
        }

        // GET: tipo_documento/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_documento tipo_documento = db.tipo_documento.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // POST: tipo_documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tipo_documento tipo_documento = db.tipo_documento.Find(id);
            db.tipo_documento.Remove(tipo_documento);
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
