using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_fichas.WebApi.ViewModels
{
    public class ActividadDetalleDTO
    {
        public int Actividad_ID { get; set; }
        public int Actividad_Cantidad { get; set; }
        public string Actividad_Nombre { get; set; }
        public DateTime Actividad_Fecha { get; set; }
        public double Actividad_Valor { get; set; }

        public string Estado_Nombre { get; set; }

        public string Moneda_Alias { get; set; }

        public int Cliente_ID { get; set; }
        public string Cliente_nombreFantasia { get; set; }

        public int Pedido_ID { get; set; }
        public string Pedido_Nombre { get; set; }
         
    }
}