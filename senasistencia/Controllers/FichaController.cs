using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using senasistencia.Models;
using senasistencia.Controllers;

namespace senasistencia.Controllers
{
    public class FichaController : Controller
    {
        SENASISTENCIAEntities Basedatos = new SENASISTENCIAEntities();
        // GET: Ficha
        public ActionResult Index()
        {
            return View(Basedatos.FICHA.ToList<FICHA>());
        }
       
        // GET: Ficha/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ficha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ficha/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ficha/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ficha/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ficha/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ficha/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
