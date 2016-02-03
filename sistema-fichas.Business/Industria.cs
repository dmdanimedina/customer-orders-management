using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public class Industria : Entity<int>
    {

        [StringLength(245)]
        public string Nombre { get; set; }

        [DefaultValueAttribute(1)]
        public byte Estado { get; set; }

        [DisplayName("Clientes")]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
