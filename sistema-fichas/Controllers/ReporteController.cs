using System;
using sistema_fichas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistema_fichas.Controllers
{
    public class ReporteController : SistemaFichasController
    {

        public ActionResult Index()
        {
            return View();
        }


       /* public ActionResult Cliente() {
            var clientes = from Clientes in db.Clientes
                           select Clientes;

            return View(clientes.ToList());
        }
        */
    }
}
