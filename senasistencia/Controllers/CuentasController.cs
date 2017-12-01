using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace senasistencia.Controllers
{
    public class CuentasController : Controller
    {
        // GET: Cuenta
        public ActionResult Login()
        {
            return View();
        }
    }
}