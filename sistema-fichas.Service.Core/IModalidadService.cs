using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service.Core
{
    public interface IModalidadService : IEntityService<Modalidad>
    {
        Modalidad GetById(int Id);
    }
}
