using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service.Core
{
    public interface IContactoService : IEntityService<Contacto>
    {
        Contacto GetById(int Id);
        IEnumerable<Contacto> GetAllByCriteria(string searchCriteria, string ContactoAttribute, bool? OnlyActives = true);
        IEnumerable<Contacto> GetAllByClienteId(int Id, bool? OnlyActives = true);

    }
}
