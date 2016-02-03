using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema_fichas.Business
{
    public enum TipoEstadoPatente
    {
        Inactiva = 0,
        Activa = 1,
        Mantencion = 2,
        Error = -1
    }

    public class Patente : AuditableEntity<long>
    {
        public Patente()
        {
            this.Estado = TipoEstadoPatente.Activa.GetHashCode();
            this.FechaIngreso = DateTime.Now;
        }

        [DisplayName("Placa Patente")]
        [Required(ErrorMessage = "Placa patente es requerida.")]
        [StringLength(6, ErrorMessage = "Placa patente no puede tener más de 6 digitos.")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Numero { get; set; }
        public int? Estado { get; set; }
        [DisplayName("Fecha Creación")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public DateTime? FechaIngreso { get; set; }
        [DisplayName("Fecha Creación")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public DateTime? FechaValidacion { get; set; }
        [DisplayName("N° GPS")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Gps_ID { get; set; }

        [DisplayName("Estado")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string NombreEstado 
        {
            get
            {
              return (this.Estado != null) ? ((TipoEstadoPatente)this.Estado).ToString() : "N/A";  
            }
                
        }

        [DisplayName("Cliente")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public long? Cliente_ID { get; set; }

        [DisplayName("Comentario")]
        public String Comentario { get; set; }

        [DisplayName("Pedido")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public long? PedidoDetalle_ID { get; set; }

        [DisplayName("Pedido")]
        [DisplayFormat(NullDisplayText ="N/A")]
        public int? Pedido_ID { get; set; }
        
        [ForeignKey("PedidoDetalle_ID")]
        [DisplayName("PedidoDetalle")]
        public virtual PedidoDetalle PedidoDetalle { get; set; }
        
        [ForeignKey("Cliente_ID")]
        [DisplayName("Cliente")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Pedido_ID")]
        [DisplayName("Pedido")]
        public virtual Pedido Pedido { get; set; }


    }
}
