using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service.Core
{
    public interface ITipoClienteService : IEntityService<TipoCliente>
    {
        TipoCliente GetById(int Id);
    }
}
