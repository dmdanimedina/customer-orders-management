using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_fichas.WebApi.ViewModels
{
    public class EstadoDTO
    {
        public string gps_id { get; set; }
        public string patente { get; set; }
        public int estado {get; set;}
        public int id { get; set; }
        
    }
}