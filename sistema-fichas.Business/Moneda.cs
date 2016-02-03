using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public class Moneda : Entity<int>
    {
        [StringLength(245)]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Nombre { get; set; }

        [StringLength(245)]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Alias { get; set; }

        [DefaultValue(1)]
        public int Estado { get; set; }
    }
}
