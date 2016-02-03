using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sistema_fichas.Business
{
    class OrdenTrabajo : AuditableEntity<long>
    {
        public OrdenTrabajo() 
        {
        
        }

        int ott_id { get; set; }
        int ott_num { get; set; }
        string ott_nombre { get; set; }
        string ott_contacto { get; set; }
        string ott_ubicacion { get; set; }
        string ott_telefono { get; set; }
        string ott_comuna { get; set; }
        string ott_fecha { get; set; }

    }
}
