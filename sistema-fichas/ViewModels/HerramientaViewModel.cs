using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using sistema_fichas.Business;

namespace sistema_fichas.ViewModels
{
    public class HerramientaViewModel
    {
        public Pedido pedido {get; set;}
        public int[] listaHerramientas { get; set; }


    }
}