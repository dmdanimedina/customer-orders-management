using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service.Core
{
    public interface IPedidoService : IEntityService<Pedido>
    {
        Pedido GetById(int Id);
        IEnumerable<Pedido> GetAllByClienteId(int Id, bool? OnlyActive = true);
        IEnumerable<Pedido> GetAllOperaciones(string criteria, bool? OnlyActives = true); 
        IEnumerable<Pedido> GetAllByCriteria(string searchCriteria, string ContactoAttribute, bool? OnlyActives = true);
    }
}
