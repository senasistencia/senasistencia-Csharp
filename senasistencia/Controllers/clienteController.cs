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
    public class clienteController : Controller
    {
        private DBContext db = new DBContext();

        // GET: cliente
        public ActionResult Index()
        {
            var cliente = db.cliente.Include(c => c.cargo).Include(c => c.perfil).Include(c => c.tipo_documento);
            return View(cliente.ToList());
        }

        // GET: cliente/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: cliente/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cargo = new SelectList(db.cargo, "ID_Cargo", "Tipo_Cargo");
            ViewBag.ID_Perfil = new SelectList(db.perfil, "ID_Perfil", "Perfil1");
            ViewBag.ID_Tipo_Documento = new SelectList(db.tipo_documento, "ID_Tipo_Documento", "Nombre_TipoDeDocumento");
            return View();
        }

        // POST: cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DocumentoCliente,ID_Tipo_Documento,PrimerNombre_Cliente,SegundoNombre_Cliente,PrimerApellido_Cliente,SegundoApellido_Cliente,Correo_Cliente,Telefono_Cliente,ID_Cargo,ID_Perfil,Estado_Cliente,FechaDeCreacion_Cliente,FechaDeInactivacion_Cliente")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cargo = new SelectList(db.cargo, "ID_Cargo", "Tipo_Cargo", cliente.ID_Cargo);
            ViewBag.ID_Perfil = new SelectList(db.perfil, "ID_Perfil", "Perfil1", cliente.ID_Perfil);
            ViewBag.ID_Tipo_Documento = new SelectList(db.tipo_documento, "ID_Tipo_Documento", "Nombre_TipoDeDocumento", cliente.ID_Tipo_Documento);
            return View(cliente);
        }

        // GET: cliente/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cargo = new SelectList(db.cargo, "ID_Cargo", "Tipo_Cargo", cliente.ID_Cargo);
            ViewBag.ID_Perfil = new SelectList(db.perfil, "ID_Perfil", "Perfil1", cliente.ID_Perfil);
            ViewBag.ID_Tipo_Documento = new SelectList(db.tipo_documento, "ID_Tipo_Documento", "Nombre_TipoDeDocumento", cliente.ID_Tipo_Documento);
            return View(cliente);
        }

        // POST: cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DocumentoCliente,ID_Tipo_Documento,PrimerNombre_Cliente,SegundoNombre_Cliente,PrimerApellido_Cliente,SegundoApellido_Cliente,Correo_Cliente,Telefono_Cliente,ID_Cargo,ID_Perfil,Estado_Cliente,FechaDeCreacion_Cliente,FechaDeInactivacion_Cliente")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cargo = new SelectList(db.cargo, "ID_Cargo", "Tipo_Cargo", cliente.ID_Cargo);
            ViewBag.ID_Perfil = new SelectList(db.perfil, "ID_Perfil", "Perfil1", cliente.ID_Perfil);
            ViewBag.ID_Tipo_Documento = new SelectList(db.tipo_documento, "ID_Tipo_Documento", "Nombre_TipoDeDocumento", cliente.ID_Tipo_Documento);
            return View(cliente);
        }

        // GET: cliente/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            cliente cliente = db.cliente.Find(id);
            db.cliente.Remove(cliente);
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
