using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema_fichas.Business;
using sistema_fichas.ViewModels;
using LinqKit;
using System.Net;
using System.Data.Entity;
using sistema_fichas.Service.Core;
using sistema_fichas.Helpers;

namespace sistema_fichas.Controllers
{
    public class ContactoController : SistemaFichasController
    {
        IContactoService _ContactoService;
        IClienteService _ClienteService;

        public ContactoController(
            IContactoService ContactoService, 
            IClienteService ClienteService)
        {
            this._ContactoService = ContactoService;
            this._ClienteService = ClienteService;
        }


        public ActionResult Index(string busqueda, string filtro_tipo)
        {
            return View(_ContactoService.GetAllByCriteria(busqueda, filtro_tipo).ToList());
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = _ContactoService.GetById(id);
            if (contacto == null) {
                return HttpNotFound();
            }

            return View(contacto);
        }

        [HttpGet]
        public ActionResult CrearContacto(int Cliente_ID) 
        {
            Contacto contacto = new Contacto();
            try {
                contacto.Cliente = _ClienteService.GetById(Cliente_ID);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_CrearContacto", contacto);
                }
                return View(contacto);
            }
            catch (Exception e) {
               return View(contacto);
            }
            
        
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearContacto(Contacto contacto)
        {
            try
            {

                string msg;
                Boolean status;
                if (Request.IsAjaxRequest())
                {
                    if (ModelState.IsValid)
                    {
                        status = true;
                        msg = "Contacto creado <b>exitósamente</b>";
                        _ContactoService.Create(contacto);

                    }
                    else
                    {
                        status = false;
                        msg = "No se pudo guardar la información exitósamente, intente de nuevo.";
                    }
                    return Json(new { status = status, msg = msg, url = (Url.Action("Details", "Cliente", new { ID = contacto.Cliente_ID })) });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int contactoID)
        {
            if (contactoID == null)
            {
                return Json("Ocurrio un error en la solicitud");
            }
            Contacto contacto = _ContactoService.GetById(contactoID);
            if (contacto == null)
            {
                return Json( "No existe el contacto solicitado" );
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_CrearContacto", contacto);
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contacto contacto)
        {
            try
            {

                string msg;
                Boolean status;
                if (Request.IsAjaxRequest())
                {
                    if (ModelState.IsValid)
                    {
                        status = true;
                        msg = "Contacto editado <b>exitósamente</b>";
                        _ContactoService.Update(contacto);
                    }
                    else
                    {
                        status = false;
                        msg = "No se pudo guardar la información exitósamente, intente de nuevo.";
                    }
                    // Funcion que retorna un mensaje del resultado de la creacion rapida
                    return Json(new { status = status, msg = msg, url = (Url.Action("Details", "Cliente", new { ID = contacto.Cliente_ID })) });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        [HttpPost]
        public ActionResult Anular(int ContactoID)
        {
            String msg_error = "Ocurrio un problema al intentar eliminar el contacto, por favor intente de nuevo.";
            String msg_success = "El Contacto ha sido eliminado exitosamente";

            try
            {
                if (ContactoID == null)
                {
                    return Json(new { status = status_error, msg = msg_error });
                }
                Contacto contacto = _ContactoService.GetById(ContactoID);
                if (contacto == null)
                {
                    return Json(new { status = status_error, msg = msg_error });
                }

                contacto.Estado = 0;
                _ContactoService.Update(contacto);

                return Json(new { status = status_success, msg = msg_success });

            }
            catch (Exception e)
            {
                return Json(new { status = status_error, msg = msg_error + System.Environment.NewLine + e.Message });
            };

        }
    }
}
