using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    // Interface base de Entidad
    // Cualquier metodo generico debe ser definido acá

    public interface IEntity<T>
    {
        T ID { get; set; }
        Boolean Status { get; set; }
    }
}
