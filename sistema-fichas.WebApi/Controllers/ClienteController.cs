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
    public class ClienteController : ApiController
    {
        IClienteService _ClienteService;
        IPedidoService _PedidoService;

        public ClienteController(IClienteService ClienteService, IPedidoService PedidoService)
        {
            _ClienteService = ClienteService;
            _PedidoService = PedidoService;
        }


        public IList<ClienteDTO> Get()
        {
            IList<ClienteDTO> clientesConPedidos = new List<ClienteDTO>();
            IList<Cliente> clientes = _ClienteService.GetAllWithPedidos(5).ToList();

            foreach (Cliente cl in clientes)
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.ID = cl.ID;
                cliente.NombreFantasia = cl.NombreFantasia;
                cliente.RazonSocial = cl.RazonSocial;
                cliente.RUT = cl.Rut;
                clientesConPedidos.Add(cliente);
            }


            return clientesConPedidos.ToList();
        }

        // TODOS LOS PEDIDOS DE UN CLIENTE SEGUN ID CLIENTE
        public IList<PedidoDTO> Get(int id)
        {
            int aprobado_operaciones = TipoEstadoPedido.Aprobado_Operaciones.GetHashCode();
            int estado_inactivo = TipoEstadoDetalle.Inactivo.GetHashCode();
            int estado_finalizado = TipoEstadoDetalle.Finalizado.GetHashCode();
            int tipo_actividad = TipoPedidoDetalle.Actividad.GetHashCode();

            IEnumerable<Pedido> pedidos = _PedidoService.GetAllByClienteId(id, true).ToList().Where(x => x.PedidosDetalle.Where(y => y.Tipo == tipo_actividad && y.EstadoDetalle.Estado != estado_inactivo && y.EstadoDetalle.Estado != estado_finalizado).Count() > 0 && x.EstadoPedido.Estado == aprobado_operaciones);
            IList<PedidoDTO> pedidosDTO = new List<PedidoDTO>();
            
            foreach(Pedido p in pedidos)
            {
                PedidoDTO pedido = new PedidoDTO();
                pedido.ID = p.ID;
                pedido.Nombre = p.ID.ToString();
                pedido.Fecha = (p.FechaInicio != null) ? p.FechaInicio.Value.ToString("dd/MM/yyyy") : DateTime.MinValue.ToString("dd/MM/yyyy");
                pedido.Fecha = pedido.Fecha.Replace('-', '/');
                pedidosDTO.Add(pedido);
            }
            return pedidosDTO;
        }

        // POST api/cliente
        public void Post([FromBody]string value)
        {
        }

        // PUT api/cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/cliente/5
        public void Delete(int id)
        {
        }
    }
}
