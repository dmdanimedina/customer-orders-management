using sistema_fichas.Business;
using sistema_fichas.Filters;
using sistema_fichas.Service.Core;
using sistema_fichas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace sistema_fichas.Controllers
{
    [InitializeSimpleMembership]
    public class OperacionesController : SistemaFichasController
    {
        IPedidoService _PedidoService;
        IPedidoDetalleService _PedidoDetalleService;
        IEstadoPedidoService _EstadoPedidoService;
        IEstadoDetalleService _EstadoDetalleService;
        ICatalogoService _CatalogoService;
        IMonedaService _MonedaService;
        IClienteService _ClienteService;

        public OperacionesController(IPedidoService PedidoService, IPedidoDetalleService PedidoDetalleService, IClienteService ClienteService, IEstadoDetalleService EstadoDetalleService, IEstadoPedidoService EstadoPedidoService, ICatalogoService CatalogoService, IMonedaService MonedaService)
        {
            _PedidoService = PedidoService;
            _EstadoPedidoService = EstadoPedidoService;
            _CatalogoService = CatalogoService;
            _MonedaService = MonedaService;
            _EstadoDetalleService = EstadoDetalleService;
            _ClienteService = ClienteService;
            _PedidoDetalleService = PedidoDetalleService;
        }

        public ActionResult Index(string busqueda, string tipo_filtro)
        {
            return View(_PedidoService.GetAllOperaciones(busqueda, true).ToList());
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult CrearActividad()
        {
            PedidoViewModel pedidoVM = new PedidoViewModel();
            
            try
            {
                
                pedidoVM.Productos = _CatalogoService.GetAllByType(TipoPedidoDetalle.Actividad.GetHashCode());
                pedidoVM.Monedas = _MonedaService.GetAll();
                pedidoVM.Clientes = _ClienteService.GetAll();

                pedidoVM.PedidoDetalle.Tipo = TipoPedidoDetalle.Actividad.GetHashCode();
                
                return View(pedidoVM);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpPost]
        public ActionResult CrearActividad(PedidoViewModel pedidoVM) {

            Pedido pedido = pedidoVM.Pedido;
            PedidoDetalle actividad = pedidoVM.PedidoDetalle;
            

            try 
            {

                pedido.UserProfile_ID = (WebSecurity.CurrentUserId);
                pedido.EstadoPedido_ID = _EstadoPedidoService.GetIdEstado(TipoEstadoPedido.Aprobado_Comercial.GetHashCode());

                actividad.EstadoDetalle_ID = _EstadoDetalleService.GetIdEstadoInicial();
                actividad.Tipo = TipoPedidoDetalle.Actividad.GetHashCode();


                pedido.PedidosDetalle.Add(actividad);
                _PedidoService.Create(pedido);

                return RedirectToAction("VerPedido", new { id = pedido.ID });

            }catch(Exception e){
                pedidoVM.Productos = _CatalogoService.GetAllByType(TipoPedidoDetalle.Actividad.GetHashCode());
                pedidoVM.Monedas = _MonedaService.GetAll();
                pedidoVM.Clientes = _ClienteService.GetAll();
                return View(pedidoVM);
            }
        }


        public ActionResult VerPedido(int id)
        {

            PedidoViewModel PedidoVM = new PedidoViewModel();
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Pedido pedido = _PedidoService.GetById(id);
                if (pedido == null)
                {
                    return HttpNotFound();
                }

                PedidoVM.Pedido = pedido;
                PedidoVM.PedidosDetalles = PedidoVM.Pedido.PedidosDetalle.Where(s => s.EstadoDetalle.Estado != TipoEstadoDetalle.Inactivo.GetHashCode()) as IEnumerable<PedidoDetalle>;
                return View(PedidoVM);

            }
            catch (Exception e)
            {
                return View(PedidoVM);
            }
        }


        public ActionResult AgregarActividad(int PedidoID)
        {
            PedidoViewModel ProductoVM = new PedidoViewModel();
            ProductoVM.Productos = _CatalogoService.GetAllByType(TipoPedidoDetalle.Actividad.GetHashCode());
            ProductoVM.Monedas = _MonedaService.GetAll();
            try
            {
                if (Request.IsAjaxRequest())
                {
                    ProductoVM.PedidoDetalle.Pedido_ID = PedidoID;
                    ProductoVM.PedidoDetalle.Tipo = TipoPedidoDetalle.Actividad.GetHashCode();
                    return PartialView("_AgregarActividad", ProductoVM);
                }
                return View(ProductoVM);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarActividad(PedidoDetalle PedidoDetalle)
        {

            try
            {
               

                if (ModelState.IsValid)
                {
                    int EstadoDetalle_ID = _EstadoDetalleService.GetIdEstadoInicial();
                    int TipoPedidoDetalle_Id = TipoPedidoDetalle.Actividad.GetHashCode();


                    PedidoDetalle.Tipo = TipoPedidoDetalle_Id;
                    PedidoDetalle.EstadoDetalle_ID = EstadoDetalle_ID;
                    _PedidoDetalleService.Create(PedidoDetalle);

                    var Pedidos = _PedidoDetalleService.GetPedidosDetalleActividad(PedidoDetalle.Pedido_ID);
                    return Json(new { msg = "Detalle creado <b>exitosamente</b>", status = status_success, contenido = RenderPartialViewToString("_ActividadesList", Pedidos) });
                }
                else
                {
                    return Json(new { msg = "Ocurrio un error, por favor intente de nuevo", status = status_error });
                }

            }
            catch (Exception e)
            {
                return Json(new { msg = "Ocurrio un error, por favor intente de nuevo" + System.Environment.NewLine + e.Message, status = false });
            }

        }


        [HttpPost]
        public ActionResult CambiarEstado(int PedidoID, int Estado)
        {
            String msg_error = "Ocurrio un problema al intentar activar el pedido, por favor intente de nuevo.";
            String msg_success = "El Pedido ha sido actualizado exitosamente";

            try
            {
                if (PedidoID == null)
                    throw new Exception("Detalle: Debe especificar una ID de pedido.");

                Pedido Pedido = _PedidoService.GetById(PedidoID);
                ViewBag.iSOwner = ((WebSecurity.CurrentUserId) == Pedido.UserProfile_ID) ? true : false;

                if (Pedido == null)
                    throw new Exception("Detalle: El pedido no se encuentra en la BD.");

                int EstadoID = _EstadoPedidoService.GetIdEstado(Estado);
                
                if (EstadoID.Equals(0))
                    throw new Exception("Detalle: El estado seleccionado no se encuentra en la BD.");

                Pedido.EstadoPedido_ID = EstadoID;
                _PedidoService.Update(Pedido);
                return Json(new { status = status_success, msg = msg_success, url = Url.Action("Details", "Pedido", new { ID = PedidoID }), contenido = RenderPartialViewToString("~/Views/Pedido/_PedidoDetalle.cshtml", Pedido), contenidoBotones = RenderPartialViewToString("~/Views/Pedido/_BotonesPedidoDetalle.cshtml", Pedido) });
            }
            catch (Exception e)
            {
                return Json(new { status = status_error, msg = msg_error + System.Environment.NewLine + e.Message });
            };

        }


    }
}
