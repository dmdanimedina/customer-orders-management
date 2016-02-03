using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository.Core
{
    public interface IContactoRepository : IGenericRepository<Contacto>
    {
        Contacto GetById(int Id);

        IEnumerable<Contacto> GetAll(bool? OnlyActive);
        IEnumerable<Contacto> GetAllByCriteria(string attributeName, string attributeValue);
        IEnumerable<Contacto> GetAllByClienteId(int Id, bool? OnlyActives = true);
    }
}
