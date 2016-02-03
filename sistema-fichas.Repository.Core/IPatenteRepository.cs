using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository.Core
{
    public interface IPatenteRepository : IGenericRepository<Patente>
    {
        Patente GetById(int Id);
        IEnumerable<Patente> GetAllByPedidoId(int Pedido_ID, bool? OnlyActives = true);
        IEnumerable<Patente> GetAllByClienteId(long Cliente_ID, bool? OnlyActives = true);
        IEnumerable<Patente> GetAllByPedidoDetalleId(int PedidoDetalle_ID, bool? OnlyActives = true);
        IEnumerable<Pedido> GetAll(bool? OnlyActives);
    }
}
