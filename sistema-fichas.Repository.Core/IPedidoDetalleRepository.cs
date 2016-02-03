using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository.Core
{
    public interface IPedidoDetalleRepository : IGenericRepository<PedidoDetalle>
    {
        PedidoDetalle GetById(int Id);
        IEnumerable<PedidoDetalle> GetAllByPedidoId(int Pedido_ID, int? TipoPedidoDetalle_ID, bool? OnlyActives = true);
        IEnumerable<PedidoDetalle> GetActividadesNoFinalizadas(int Pedido_ID);
    }
}
