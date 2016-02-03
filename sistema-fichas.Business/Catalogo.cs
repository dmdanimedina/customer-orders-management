using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public class Catalogo : Entity<int>
    {
        [Required(ErrorMessage = "Debe Ingresar un Nombre")]
        [DisplayName("Nombre")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [MaxLength(255)]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe Ingresar un Valor base UF")]
        [DisplayName("Valor Base UF")]
        [DefaultValue(0)]
        public double ValorBaseUF { get; set; }

        [Required(ErrorMessage = "Debe Ingresar un Valor base CLP")]
        [DisplayName("Valor Base CLP")]
        [DefaultValue(0)]
        public double ValorBaseCLP { get; set; }

        [Required(ErrorMessage = "Debe Ingresar un Tipo")]
        [DisplayName("Tipo")]
        public int Tipo { get; set; }

        [DisplayName("Estado")]
        public int Estado { get; set; }

        public virtual ICollection<PedidoDetalle> PedidosDetalle { get; set; }
        public virtual ICollection<Herramienta> Herramientas { get; set; }
    }
}
