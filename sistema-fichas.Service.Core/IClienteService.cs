using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service.Core
{
    public interface IClienteService : IEntityService<Cliente>
    {
        Cliente GetById(long Id);
        IEnumerable<Cliente> GetAllByCriteria(string searchCriteria, string ContactoAttribute, bool? OnlyActives = true);
        IEnumerable<Cliente> GetAllWithPedidos(int? EstadoPedido);
    }
}
