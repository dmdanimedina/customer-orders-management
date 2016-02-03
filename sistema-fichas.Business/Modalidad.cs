using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public class Modalidad : Entity<int>
    {
        [Required]
        [DisplayName("Nombre")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Nombre { get; set; }

        [DisplayName("Estado")]
        public int Estado { get; set; }

        public virtual ICollection<PedidoDetalle> PedidosDetalle { get; set; }
    }
}
