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
    public class Cliente : AuditableEntity<long>
    {
        public Cliente(){
            this.FechaCreacion = DateTime.Now;
            this.Direcciones = new HashSet<Direccion>();
            this.Contactos = new HashSet<Contacto>();
            this.Pedidos = new HashSet<Pedido>();
            this.Patentes = new HashSet<Patente>();

            this.TipoCliente_ID = 1;
            this.Estado = 1;
            
        }

        //[Index("RutUnicoCliente", 1, IsUnique = true)]
        [Required(ErrorMessage = "Rut es requerido.")]
        [StringLength(245)]
        public String Rut { get; set; }

        [StringLength(245)]
        [Required(ErrorMessage = "Nombre es requerido.")]
        [DisplayName("Nombre fantasía")]
        public string NombreFantasia { get; set; }

        [StringLength(245)]
        [DisplayName("Razón Social")]
        [Required(ErrorMessage = "Razón Social es requerido.")]
        public string RazonSocial { get; set; }

        [StringLength(245)]
        [Required(ErrorMessage = "Giro es requerido.")]
        public string Giro { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Teléfono es requerido.")]
        public string Telefono { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }

        [DefaultValue(1)]
        [DisplayName("Estado Cliente")]
        public int Estado { get; set; }

        [DisplayName("Industria")]
        [Required(ErrorMessage = "Industria es requerido.")]
        public int? Industria_ID { get; set; }

        [DisplayName("Ejecutivo Asignado")]
        [Required(ErrorMessage = "Ejecutivo asignado es requerido.")]
        public int User_ID { get; set; }

        //[Required(ErrorMessage = "Tipo es requerido.")]
        [DisplayName("Tipo de Cliente")]
        public int? TipoCliente_ID { get; set; }

        [DisplayName("Contrato")]
        public string Contrato { get; set; }

        [ForeignKey("Industria_ID")]
        [DisplayName("Industria")]
        public virtual Industria Industria { get; set; }

        [ForeignKey("TipoCliente_ID")]
        [DisplayName("Tipo Cliente")]
        public virtual TipoCliente TipoCliente { get; set; }

        [ForeignKey("User_ID")]
        [DisplayName("Responsable")]
        public virtual UserProfile Usuario { get; set; }


        public virtual ICollection<Direccion> Direcciones { get; set; }
        public virtual ICollection<Contacto> Contactos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Patente> Patentes { get; set; }

        

    }
}
