using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_fichas.WebApi.ViewModels
{
    public class PedidoConDetalles
    {
        public PedidoConDetalles() 
        {
        
        }

        public int Pedido_ID { get; set; }
        public DateTime Pedido_FechaInicio { get; set; }
        
        public int Estado_ID { get; set; }
        public int Estado_Codigo { get; set; }
        public string Estado_Nombre { get; set; }

        public int Ejecutivo_ID { get; set; }
        public string Ejecutivo_Nombre { get; set; }

        public IList<ActividadDetalleDTO> Actividades { get; set; }
 
    }
}