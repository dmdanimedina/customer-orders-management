using sistema_fichas.Business;
using sistema_fichas.Service.Core;
using sistema_fichas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sistema_fichas.WebApi.Controllers
{
    public class ActividadController : ApiController
    {
        IPedidoDetalleService _PedidoDetalleService;
        IPedidoService _PedidoService;
        IEstadoDetalleService _EstadoDetalleService;
        IPatenteService _PatenteService;

        public ActividadController(IPedidoDetalleService PedidoDetalleService, IEstadoDetalleService EstadoDetalleService, IPedidoService PedidoService, IPatenteService PatenteService) 
        {
            _PedidoDetalleService = PedidoDetalleService;
            _EstadoDetalleService = EstadoDetalleService;
            _PatenteService = PatenteService;
            _PedidoService = PedidoService;
        }

        public IEnumerable<ActividadDTO> Get()
        {
            return new List<ActividadDTO>();
        }


        public ActividadDetalleDTO Get(int id)
        {
            var pedidoDetalle = _PedidoDetalleService.GetById(id);
            var actividad = new ActividadDetalleDTO();

            actividad.Actividad_ID = unchecked((int)pedidoDetalle.ID);
            actividad.Actividad_Nombre = pedidoDetalle.Catalogo.Nombre;
            actividad.Actividad_Cantidad = pedidoDetalle.Cantidad.Value;
            actividad.Actividad_Fecha = pedidoDetalle.FechaInicio.Value;
            actividad.Actividad_Valor = pedidoDetalle.Valor.Value;

            actividad.Estado_Nombre = pedidoDetalle.EstadoDetalle.Nombre;
            actividad.Moneda_Alias = pedidoDetalle.Moneda.Alias;

            
            actividad.Cliente_ID = unchecked((int)pedidoDetalle.Pedido.Cliente_ID);
            actividad.Cliente_nombreFantasia = pedidoDetalle.Pedido.Cliente.NombreFantasia;

            actividad.Pedido_ID = pedidoDetalle.Pedido_ID;
            actividad.Pedido_Nombre = pedidoDetalle.Pedido_ID.ToString();

            return actividad;
        }


        // POST api/actividad
        public HttpResponseMessage Post([FromBody] EstadoDTO estado)
        {
            try 
            {
                PedidoDetalle actividad = _PedidoDetalleService.GetById(estado.id);
                bool actualizarPedido = false;
                if (actividad == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                int estado_activo = TipoEstadoDetalle.Activo.GetHashCode();
                int estado_agendado = TipoEstadoDetalle.Agendado.GetHashCode();
                int estado_finalizado = TipoEstadoDetalle.Finalizado.GetHashCode();
                int estado_parcial = TipoEstadoDetalle.Parcial.GetHashCode();

                if (estado.estado == estado_activo)
                    actividad.EstadoDetalle_ID = _EstadoDetalleService.GetIdEstado(estado_activo);

                if (estado.estado == estado_agendado)
                    actividad.EstadoDetalle_ID = _EstadoDetalleService.GetIdEstado(estado_agendado); ;

                if (estado.estado == estado_finalizado)
                {

                    if (actividad.Cantidad > actividad.Finalizado)
                    {
                        actividad.Finalizado++;
                        if (actividad.Finalizado == actividad.Cantidad)
                        {
                            actividad.EstadoDetalle_ID = _EstadoDetalleService.GetIdEstado(estado_finalizado);
                            actualizarPedido = true;
                        }
                        else
                        {
                            actividad.EstadoDetalle_ID = _EstadoDetalleService.GetIdEstado(estado_parcial);
                        }
                    }
                    else
                    {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }
                }
                _PedidoDetalleService.Update(actividad);
                _PatenteService.ValidarPatente(estado.patente,estado.gps_id);

                if (actualizarPedido)
                {
                    int tieneActPendientes = actividad.Pedido.PedidosDetalle.Where(x => x.Tipo == TipoPedidoDetalle.Actividad.GetHashCode() && x.EstadoDetalle.Estado != TipoEstadoDetalle.Finalizado.GetHashCode() && x.EstadoDetalle.Estado != TipoEstadoDetalle.Finalizado.GetHashCode()).Count();
                    if (tieneActPendientes == 0)
                    {
                        actividad.Pedido.EstadoPedido_ID = 9;
                        _PedidoService.Update(actividad.Pedido);
                    }
                }


                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            

        }

        // PUT api/actividad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/actividad/5
        public void Delete(int id)
        {
        }
    }
}
