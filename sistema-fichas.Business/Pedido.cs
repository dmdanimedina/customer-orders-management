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
    public class Pedido : Entity<int>
    {
        public Pedido() {
            this.FechaInicio = DateTime.Now;
            this.FechaTermino = DateTime.Now;
            this.Facturado = false;
            this.PedidosDetalle = new HashSet<PedidoDetalle>();
            this.Patentes = new HashSet<Patente>();
        }

        [DisplayName("Fecha Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true, NullDisplayText = "--")]
        public DateTime? FechaInicio { get; set; }

        [DisplayName("Fecha Termino")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true, NullDisplayText = "--")]
        public DateTime? FechaTermino { get; set; }

        [DisplayName("Facturado")]
        public bool Facturado { get; set; }

        [DisplayName("Cliente")]
        public long Cliente_ID { get; set; }

        [DisplayName("Ejecutivo")]
        public int UserProfile_ID { get; set; }

        [DisplayName("Estado")]
        public int? EstadoPedido_ID { get; set; }

        [ForeignKey("Cliente_ID")]
        [DisplayName("Cliente")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("EstadoPedido_ID")]
        [DisplayName("Estado")]
        public virtual EstadoPedido EstadoPedido { get; set; }

        [ForeignKey("UserProfile_ID")]
        [DisplayName("Ejecutivo")]
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<PedidoDetalle> PedidosDetalle { get; set; }
        public virtual ICollection<Adjunto> Adjuntos { get; set; }

        [DisplayName("Patentes")]
        public virtual ICollection<Patente> Patentes { get; set; }



    }
}
