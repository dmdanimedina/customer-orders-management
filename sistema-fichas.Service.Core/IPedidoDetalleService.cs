using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service.Core
{
    public interface IPedidoDetalleService : IEntityService<PedidoDetalle>
    {
        PedidoDetalle GetById(int Id);

        IEnumerable<PedidoDetalle> GetPedidosDetalleHerramienta(int Pedido_ID);
        IEnumerable<PedidoDetalle> GetPedidosDetalleServicio(int Pedido_ID);
        IEnumerable<PedidoDetalle> GetPedidosDetalleProducto(int Pedido_ID);
        IEnumerable<PedidoDetalle> GetPedidosDetalleActividad(int Pedido_ID);

        IEnumerable<PedidoDetalle> GetAllByClienteId(long Cliente_ID, bool? OnlyActives = true);
        IEnumerable<PedidoDetalle> GetAllByPedidoId(int Pedido_ID, int? TipoPedidoDetalle_ID, bool? OnlyActives = true);
        IEnumerable<PedidoDetalle> GetAllActividadesNoFinalizadas(int Pedido_ID);
    }
}
