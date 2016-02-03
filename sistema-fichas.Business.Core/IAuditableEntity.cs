using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    // Interface de auditoria
    // Definición de todos los elementos que se necesitan auditar

    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        String CreatedBy { get; set; }
        DateTime UpdatedDate { get; set; }
        String UpdatedBy { get; set; }
    }
}
