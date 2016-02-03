using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sistema_fichas.Business
{
    public class TipoCliente : Entity<int>
    {
        public string Nombre { get; set; }

        public string Sigla { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
