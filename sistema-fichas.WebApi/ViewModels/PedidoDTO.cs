using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistema_fichas.WebApi.ViewModels
{
    public class PedidoDTO
    {
        public PedidoDTO() 
        {
            this.Actividades = new List<ActividadDTO>();
        }

        public int ID { get; set; }
        public String Nombre { get; set; }
        public String Fecha { get; set; }

        public List<ActividadDTO> Actividades { get; set; }

    }
}