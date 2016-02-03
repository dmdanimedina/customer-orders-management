using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sistema_fichas.Business;

namespace sistema_fichas.ViewModels
{
    public class DireccionViewModel
    {
        public int Cliente_ID { get; set; }
        public Direccion Direccion { get; set; }
    }
}