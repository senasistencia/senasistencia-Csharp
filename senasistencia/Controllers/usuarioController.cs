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
    public class usuarioController : Controller
    {
        private DBContext db = new DBContext();

        // GET: usuario
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.cliente);
            return View(usuario.ToList());
        }

        // GET: usuario/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuario/Create
        public ActionResult Create()
        {
            ViewBag.ID_DocumentoCliente = new SelectList(db.cliente, "ID_DocumentoCliente", "PrimerNombre_Cliente");
            return View();
        }

        // POST: usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Usuario,ID_DocumentoCliente,Password_Hash,Caducidad_Password,Estado_Usuario,FechaDeCreacion_Usuario,FechaDeInactivacion_Usuario")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DocumentoCliente = new SelectList(db.cliente, "ID_DocumentoCliente", "PrimerNombre_Cliente", usuario.ID_DocumentoCliente);
            return View(usuario);
        }

        // GET: usuario/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DocumentoCliente = new SelectList(db.cliente, "ID_DocumentoCliente", "PrimerNombre_Cliente", usuario.ID_DocumentoCliente);
            return View(usuario);
        }

        // POST: usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Usuario,ID_DocumentoCliente,Password_Hash,Caducidad_Password,Estado_Usuario,FechaDeCreacion_Usuario,FechaDeInactivacion_Usuario")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DocumentoCliente = new SelectList(db.cliente, "ID_DocumentoCliente", "PrimerNombre_Cliente", usuario.ID_DocumentoCliente);
            return View(usuario);
        }

        // GET: usuario/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
