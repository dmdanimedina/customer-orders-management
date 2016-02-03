using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public class Contacto : Entity<int>
    {

        public Contacto() {
            this.Estado = 1;
        }

        [StringLength(245)]
        [DisplayName("Nombres")]
        [Required(ErrorMessage = "Nombres es un campo requerido.")]
        public string Nombres { get; set; }

        [StringLength(245)]
        [DisplayName("Cargo")]
        public string Cargo { get; set; }

        [DisplayName("Email")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        [DisplayName("Celular")]
        [Required(ErrorMessage = "Celular es un campo requerido.")]
        public string Celular { get; set; }

        [DisplayName("Tipo")]
        public int? Tipo { get; set; }

        [DefaultValueAttribute(1)]
        public byte Estado { get; set; }

        [DisplayName("Cliente")]
        public long? Cliente_ID { get; set; }

        [DisplayName("Clientes")]
        [ForeignKey("Cliente_ID")]
        public virtual Cliente Cliente { get; set; }
    }
}
