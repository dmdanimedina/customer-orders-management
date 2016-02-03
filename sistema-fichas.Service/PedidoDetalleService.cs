using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using sistema_fichas.Service.Core;

namespace sistema_fichas.Service
{
    public class PedidoDetalleService : EntityService<PedidoDetalle>, IPedidoDetalleService
    {
        IUnitOfWork _unitOfWork;
        IPedidoDetalleRepository _pedidoDetalleRepository;

        public PedidoDetalleService(IUnitOfWork unitOfWork, IPedidoDetalleRepository pedidoDetalleRepository)
            : base(unitOfWork, pedidoDetalleRepository)
        {
            _unitOfWork = unitOfWork;
            _pedidoDetalleRepository = pedidoDetalleRepository;
        }

        public PedidoDetalle GetById(int Id) 
        {
            return _pedidoDetalleRepository.GetById(Id);
        
        }

     

        public IEnumerable<PedidoDetalle> GetAllByClienteId(long Cliente_ID, bool? OnlyActives = true) 
        {
            if(OnlyActives.Value.Equals(true))
            {
                return _pedidoDetalleRepository.FindBy(x => x.Pedido.Cliente_ID.Equals(Cliente_ID) && x.EstadoDetalle.Estado.Equals(1));
            }
            else
            {
                return _pedidoDetalleRepository.FindBy(x => x.Pedido.Cliente_ID.Equals(Cliente_ID));
            }
        }

        public IEnumerable<PedidoDetalle> GetPedidosDetalleHerramienta(int Pedido_ID)
        {
            return this.GetAllByPedidoId(Pedido_ID, TipoPedidoDetalle.Herramienta.GetHashCode());
        }

        public IEnumerable<PedidoDetalle> GetPedidosDetalleProducto(int Pedido_ID)
        {
            return this.GetAllByPedidoId(Pedido_ID, TipoPedidoDetalle.Producto.GetHashCode());
        }

        public IEnumerable<PedidoDetalle> GetPedidosDetalleServicio(int Pedido_ID)
        {
            return this.GetAllByPedidoId(Pedido_ID, TipoPedidoDetalle.Servicio.GetHashCode());
        }

        public IEnumerable<PedidoDetalle> GetPedidosDetalleActividad(int Pedido_ID)
        {
            return this.GetAllByPedidoId(Pedido_ID, TipoPedidoDetalle.Actividad.GetHashCode());
        }

        public IEnumerable<PedidoDetalle> GetAllByPedidoId(int Pedido_ID, int? TipoPedidoDetalle_ID,bool? OnlyActives=true)
        {
                return _pedidoDetalleRepository.GetAllByPedidoId(Pedido_ID, TipoPedidoDetalle_ID, OnlyActives.Value);           
        }

        public IEnumerable<PedidoDetalle> GetAllActividadesNoFinalizadas(int Pedido_ID)
        {
            return _pedidoDetalleRepository.GetActividadesNoFinalizadas(Pedido_ID);
        }
    }
}
