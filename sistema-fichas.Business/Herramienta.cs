using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public class Herramienta : Entity<int>
    {

        [Required(ErrorMessage = "Debe Ingresar un Nombre")]
        [DisplayName("Nombre")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe Ingresar un Tipo")]
        [DisplayName("Tipo")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public int Tipo { get; set; }

        public virtual ICollection<PedidoDetalle> PedidosDetalle { get; set; }
        public virtual ICollection<Catalogo> Catalogos { get; set; }
    }
}
