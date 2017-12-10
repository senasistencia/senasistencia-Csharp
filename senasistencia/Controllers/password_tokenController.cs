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
    public class password_tokenController : Controller
    {
        private DBContext db = new DBContext();

        // GET: password_token
        public ActionResult Index()
        {
            var password_token = db.password_token.Include(p => p.usuario);
            return View(password_token.ToList());
        }

        // GET: password_token/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            password_token password_token = db.password_token.Find(id);
            if (password_token == null)
            {
                return HttpNotFound();
            }
            return View(password_token);
        }

        // GET: password_token/Create
        public ActionResult Create()
        {
            ViewBag.ID_Usuario = new SelectList(db.usuario, "ID_Usuario", "Password_Hash");
            return View();
        }

        // POST: password_token/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Token,Token_Hash,ID_Usuario,Estado_Token,FechaDeCreacion_Token,FechaDeInactivacion_Token")] password_token password_token)
        {
            if (ModelState.IsValid)
            {
                db.password_token.Add(password_token);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Usuario = new SelectList(db.usuario, "ID_Usuario", "Password_Hash", password_token.ID_Usuario);
            return View(password_token);
        }

        // GET: password_token/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            password_token password_token = db.password_token.Find(id);
            if (password_token == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Usuario = new SelectList(db.usuario, "ID_Usuario", "Password_Hash", password_token.ID_Usuario);
            return View(password_token);
        }

        // POST: password_token/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Token,Token_Hash,ID_Usuario,Estado_Token,FechaDeCreacion_Token,FechaDeInactivacion_Token")] password_token password_token)
        {
            if (ModelState.IsValid)
            {
                db.Entry(password_token).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Usuario = new SelectList(db.usuario, "ID_Usuario", "Password_Hash", password_token.ID_Usuario);
            return View(password_token);
        }

        // GET: password_token/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            password_token password_token = db.password_token.Find(id);
            if (password_token == null)
            {
                return HttpNotFound();
            }
            return View(password_token);
        }

        // POST: password_token/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            password_token password_token = db.password_token.Find(id);
            db.password_token.Remove(password_token);
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
