using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_fichas.Helpers
{
    public static class DireccionHelper
    {
        public static string  DireccionCliente(string Calle, string Numero, string Departamento, string Ciudad) {
            var direccion = Calle + " " + Numero;
            direccion = (String.IsNullOrEmpty(Departamento)) ? direccion : direccion + "Dpto. " + Departamento;
            direccion = direccion + ", " + Ciudad;
            return direccion;
        }
    }
}