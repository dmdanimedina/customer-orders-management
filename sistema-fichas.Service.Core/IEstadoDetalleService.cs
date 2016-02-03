using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service.Core
{
    public interface IEstadoDetalleService : IEntityService<EstadoDetalle>
    {
        EstadoDetalle GetById(int Id);
        int GetIdEstado(int Estado_ID);
        int GetIdEstadoInicial();
        int GetIdEstadoInactivo();
        int GetIdEstadoDeshabilitado();
    }
}
