using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema_fichas.Business;
using sistema_fichas.ViewModels;
using System.Data.Entity;
using System.Net;
using sistema_fichas.Service.Core;

namespace sistema_fichas.Controllers
{
    public class DireccionController : SistemaFichasController
    {
        IDireccionService _DireccionService;
        IClienteService _ClienteService;

        public DireccionController(IDireccionService DireccionService, IClienteService ClienteService)
        {
            _DireccionService = DireccionService;
            _ClienteService = ClienteService;
        }

        public ActionResult Create(int ClienteID)
        {
            DireccionViewModel direccion = new DireccionViewModel();
            direccion.Direccion = new Direccion();

            if (Request.IsAjaxRequest())
            {
                direccion.Cliente_ID = ClienteID;
                return PartialView("_CrearDireccion", direccion);
            }
            return View(direccion);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearDireccion(DireccionViewModel DireccionVM)
        {
            String msg_success = "Direccion creado <b>exitosamente</b>";
            String msg_error = String.Format(mensaje_error,"Crear una direccion");
            Direccion direccion = DireccionVM.Direccion;
            int Cliente_ID = DireccionVM.Cliente_ID;
            try
            {
                Cliente cliente = _ClienteService.GetById(Cliente_ID);
            
                if (Request.IsAjaxRequest())
                {   
                    if (ModelState.IsValid)
                    {
                        direccion.Clientes.Add(cliente);
                        _DireccionService.Create(direccion);
                        return Json(new { status = status_success, msg = msg_success, url = (Url.Action("Details", "Cliente", new { ID = cliente.ID })) });
                    }
                    else
                    {
                        return Json(new { status = status_error, msg =  msg_error});
                    }
                    
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return Json(new { status = status_error, msg = msg_error + System.Environment.NewLine + e.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int DireccionID)
        {
            String msg_error = String.Format(mensaje_error, "borrar la direccion");
            String msg_success = "Los datos han sido actualizado exitosamente";
           
            try
            {
                Direccion direccion = new Direccion();
                direccion = _DireccionService.GetById(DireccionID);
                direccion.Estado = 0;
                _DireccionService.Update(direccion);

                return Json(new { status = status_success, msg = msg_success });
            }
            catch
            {
                return Json(new { status = status_success, msg = status_error });
            }
        }
    }
}
