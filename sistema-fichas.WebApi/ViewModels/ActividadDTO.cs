using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistema_fichas.WebApi.ViewModels
{
    public class ActividadDTO
    {
        public long ID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public String Fecha { get; set; }
        public String Descripcion { get; set; }
        public String Estado { get; set; }

    }
}