using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_fichas.ViewModels
{
    public class BusquedaViewModel
    {
        public string NombreControlador { get; set; }
        public string NombreAccion { get; set; }
        public string FiltroFormulario { get; set; }
        public string PlaceholderFormulario { get; set; }
        public string NombreCreacionRapida { get; set; }

        public BusquedaViewModel(string NC, string NA, string FF, string PF, string NCR = null)
        {
            NombreControlador = NC;
            NombreAccion = NA;
            FiltroFormulario = FF;
            PlaceholderFormulario = PF;
            NombreCreacionRapida = NCR;

        }
    }   
}