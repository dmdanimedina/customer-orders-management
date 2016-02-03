using sistema_fichas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sistema_fichas.WebApi.Controllers
{
    public class AgendaDTO
    {
        public int Cliente_ID { get; set; }
        public String Cliente_Nombre { get; set; }
        public int Pedido_ID { get; set; }
        public String Pedido_Nombre { get; set; }
        public String Pedido_Fecha { get; set; }

        public IList<ActividadDTO> actividades { get; set; }


    }
}
