using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema_fichas.Business;
using sistema_fichas.ViewModels;
using System.Net;
using LinqKit;
using System.Data.Entity;
using System.IO;
using PagedList;

using sistema_fichas.Service;
using sistema_fichas.Service.Core;

namespace sistema_fichas.Controllers
{
    public class ClienteController : SistemaFichasController
    {

        IClienteService _ClienteService;
        IPedidoService _PedidoService;
        IIndustriaService _IndustriaService;
        IUsuarioService _UsuarioService;
        IContactoService _ContactoService;
        IDireccionService _DireccionService;

        public ClienteController(IClienteService ClienteService, IPedidoService PedidoService, IIndustriaService IndustriaService, IUsuarioService UsuarioService, IContactoService ContactoService, IDireccionService DireccionService) 
        {
            this._ClienteService = ClienteService;
            this._PedidoService = PedidoService;
            this._UsuarioService = UsuarioService;
            this._IndustriaService = IndustriaService;
            this._ContactoService = ContactoService;
            this._DireccionService = DireccionService;
        }

        public ActionResult Index(string busqueda, string filtro_tipo)
        {
            return View(_ClienteService.GetAllByCriteria(busqueda, filtro_tipo, false).ToList());
        }

        public ActionResult Details(int id)
        {
            ClienteViewModel cliente = new ClienteViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente.cliente = _ClienteService.GetById(id);
            cliente.Pedidos = _PedidoService.GetAllByClienteId(id, true).ToList();
            cliente.Contactos = _ContactoService.GetAllByClienteId(id, true);
            if (cliente.cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
            
        }

        public ActionResult Create()
        {
            ClienteViewModel cliente = new ClienteViewModel();
            cliente.Industrias = _IndustriaService.GetAll();
            cliente.Usuarios = _UsuarioService.GetAll();

            if (Request.IsAjaxRequest()) {
                return PartialView("_CrearCliente", cliente);
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            try
            {
  
                Cliente cliente = new Cliente();
                cliente = clienteViewModel.cliente;
                clienteViewModel.Industrias = _IndustriaService.GetAll();
                clienteViewModel.Usuarios = _UsuarioService.GetAll();

                if (ModelState.IsValid)
                {
                    
                    

                    clienteViewModel.ContactoComercial.Tipo = 1;
                    clienteViewModel.ContactoInstalacion.Tipo = 2;
                    clienteViewModel.ContactoFacturacion.Tipo = 3;

                    cliente.Contactos.Add(clienteViewModel.ContactoComercial);
                    cliente.Contactos.Add(clienteViewModel.ContactoInstalacion);
                    cliente.Contactos.Add(clienteViewModel.ContactoFacturacion);
                    cliente.Direcciones.Add(clienteViewModel.Direccion);

                    _ClienteService.Create(cliente);
                    return RedirectToAction("Details", new { id = cliente.ID });
                }

                
                return View(clienteViewModel);
            }
            catch(Exception e)
            {
                return View(clienteViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel cliente = new ClienteViewModel();
            cliente.cliente = _ClienteService.GetById(id);
            cliente.Industrias = _IndustriaService.GetAll();
            cliente.Usuarios = _UsuarioService.GetAll();

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,RazonSocial,Rut,Telefono, Giro, IndustriaID, TipoCliente, UserID, Contrato")] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ClienteService.Update(cliente);
                    return RedirectToAction("Index");
                }

                ClienteViewModel clienteVM = new ClienteViewModel();
                clienteVM.cliente = cliente;
                clienteVM.Industrias = _IndustriaService.GetAll();
                clienteVM.Usuarios = _UsuarioService.GetAll();

                if (cliente == null)
                {
                    return HttpNotFound();
                }
                return View(clienteVM);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditModal(int clienteID)
        {
            if (clienteID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteVM = new ClienteViewModel();
            clienteVM.cliente = _ClienteService.GetById(clienteID);
            clienteVM.Usuarios = _UsuarioService.GetAll();
            clienteVM.Industrias = _IndustriaService.GetAll();
            
            if (clienteVM == null)
            {
                return HttpNotFound();
            }
            return PartialView(clienteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditModal(Cliente cliente)
        {
            String msg_error = "Ocurrio un problema al intentar editar el Cliente, por favor intente de nuevo.";
            String msg_success = "Los datos han sido actualizado exitosamente";
            
            try
            {
                if (ModelState.IsValid)
                {
                    _ClienteService.Update(cliente);
                    return Json(new { status = status_success, msg = msg_success, url = Url.Action("Details","Cliente",new {cliente.ID}) });
                }
                else
                {
                    return Json(new { status = status_error, msg = msg_error});
                }
                
            }
            catch (Exception e)
            {
                return Json(new { status = status_error, msg = msg_error + System.Environment.NewLine + e.Message });
            }



        }
    }
}
