using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sistema_fichas.Business;

namespace sistema_fichas.ViewModels
{
    public class ContactoViewModel
    {
        public Contacto Contacto { get; set; }
        public IEnumerable<Cliente> clientes { get; set; }
    }
}