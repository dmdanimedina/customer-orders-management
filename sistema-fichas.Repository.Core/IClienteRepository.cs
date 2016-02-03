using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository.Core
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Cliente GetById(long id);
        IEnumerable<Cliente> GetAll(bool? OnlyActive);
        IEnumerable<Cliente> GetAllByCriteria(string attributeName, string attributeValue);
        IEnumerable<Cliente> GetAllWithPedidos(int EstadoPedido);
    }
}
