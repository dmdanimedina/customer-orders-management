using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository.Core
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        Pedido GetById(int Id);
        IEnumerable<Pedido> GetAllByClienteId(int Id, bool? OnlyActive = true);
        IEnumerable<Pedido> GetAllByCriteria(string searchCriteria, string ContactoAttribute);
        IEnumerable<Pedido> GetAll(bool? OnlyActives);
        IEnumerable<Pedido> GetAllOperaciones(string criteria, bool? OnlyActives);
    }
}
