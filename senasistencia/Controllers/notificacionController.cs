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
    public class notificacionController : Controller
    {
        private DBContext db = new DBContext();

        // GET: notificacion
        public ActionResult Index()
        {
            var notificacion = db.notificacion.Include(n => n.aprendiz).Include(n => n.cliente).Include(n => n.Formato_Ftp);
            return View(notificacion.ToList());
        }

        // GET: notificacion/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notificacion notificacion = db.notificacion.Find(id);
            if (notificacion == null)
            {
                return HttpNotFound();
            }
            return View(notificacion);
        }

        // GET: notificacion/Create
        public ActionResult Create()
        {
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz");
            ViewBag.ID_DocumentoCliente = new SelectList(db.cliente, "ID_DocumentoCliente", "PrimerNombre_Cliente");
            ViewBag.ID_formato = new SelectList(db.Formato_Ftp, "ID_formato", "Nombre_Formato");
            return View();
        }

        // POST: notificacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Notificacion,Mensaje_Notificacion,Fecha,ID_formato,ID_DocumentoAprendiz,ID_DocumentoCliente,FechaDeCreacion_Notificacion,FechaDeInactivacion_Notificacion")] notificacion notificacion)
        {
            if (ModelState.IsValid)
            {
                db.notificacion.Add(notificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", notificacion.ID_DocumentoAprendiz);
            ViewBag.ID_DocumentoCliente = new SelectList(db.cliente, "ID_DocumentoCliente", "PrimerNombre_Cliente", notificacion.ID_DocumentoCliente);
            ViewBag.ID_formato = new SelectList(db.Formato_Ftp, "ID_formato", "Nombre_Formato", notificacion.ID_formato);
            return View(notificacion);
        }

        // GET: notificacion/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notificacion notificacion = db.notificacion.Find(id);
            if (notificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", notificacion.ID_DocumentoAprendiz);
            ViewBag.ID_DocumentoCliente = new SelectList(db.cliente, "ID_DocumentoCliente", "PrimerNombre_Cliente", notificacion.ID_DocumentoCliente);
            ViewBag.ID_formato = new SelectList(db.Formato_Ftp, "ID_formato", "Nombre_Formato", notificacion.ID_formato);
            return View(notificacion);
        }

        // POST: notificacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Notificacion,Mensaje_Notificacion,Fecha,ID_formato,ID_DocumentoAprendiz,ID_DocumentoCliente,FechaDeCreacion_Notificacion,FechaDeInactivacion_Notificacion")] notificacion notificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DocumentoAprendiz = new SelectList(db.aprendiz, "ID_DocumentoAprendiz", "Nombre_Aprendiz", notificacion.ID_DocumentoAprendiz);
            ViewBag.ID_DocumentoCliente = new SelectList(db.cliente, "ID_DocumentoCliente", "PrimerNombre_Cliente", notificacion.ID_DocumentoCliente);
            ViewBag.ID_formato = new SelectList(db.Formato_Ftp, "ID_formato", "Nombre_Formato", notificacion.ID_formato);
            return View(notificacion);
        }

        // GET: notificacion/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notificacion notificacion = db.notificacion.Find(id);
            if (notificacion == null)
            {
                return HttpNotFound();
            }
            return View(notificacion);
        }

        // POST: notificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            notificacion notificacion = db.notificacion.Find(id);
            db.notificacion.Remove(notificacion);
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
