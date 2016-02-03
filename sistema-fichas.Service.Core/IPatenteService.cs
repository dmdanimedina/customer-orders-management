using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sistema_fichas.Service.Core;
using sistema_fichas.Business;

namespace sistema_fichas.Service.Core
{
    public interface IPatenteService : IEntityService<Patente>
    {
        Patente GetById(int Id);
        IEnumerable<Patente> GetAllByPedidoId(int Pedido_ID, bool? OnlyActives = true);
        IEnumerable<Patente> GetAllByClienteId(long Cliente_ID, bool? OnlyActives = true);
        IEnumerable<Patente> GetAllByPedidoDetalleId(int PedidoDetalle_ID, bool? OnlyActives = true);
        IEnumerable<Pedido> GetAll(bool? OnlyActives);
        void ValidarPatente(string patente, string gps_id);
    }
}
