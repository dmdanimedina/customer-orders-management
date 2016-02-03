using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public class Direccion : Entity<int>
    {
        public Direccion()
        {
            this.Clientes = new HashSet<Cliente>();
            this.Estado = 1;
        }
        [DisplayName("Obs.")]
        [StringLength(245)]
        public string Observacion { get; set; }

        [DisplayName("Calle")]
        [StringLength(245)]
        [Required(ErrorMessage = "Calle es un campo requerido.")]
        public string Calle { get; set; }

        [DisplayName("Número")]
        [StringLength(245)]
        [Required(ErrorMessage = "Número es un campo requerido.")]
        public string Numero { get; set; }

        [DisplayName("Depto")]
        [StringLength(245)]
        public string Departamento { get; set; }

        [DisplayName("Ciudad")]
        [StringLength(245)]
        public string Ciudad { get; set; }

        [DisplayName("Comuna")]
        [StringLength(245)]
        public string Comuna { get; set; }

        [DisplayName("Latitud")]
        [StringLength(245)]
        public string Latitud { get; set; }

        [DisplayName("Longitud")]
        [StringLength(245)]
        public string Longitud { get; set; }

        [DefaultValue(1)]
        [DisplayName("Tipo")]
        public int? Tipo { get; set; }

        [DefaultValue(1)]
        [DisplayName("Estado")]
        public int? Estado { get; set; }

        [DisplayName("Clientes")]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
