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
    public class Adjunto : Entity<int>
    {
        public Adjunto() {
            this.Estado = 1;
            this.FechaHora = DateTime.Now;
        }
        [StringLength(245)]
        public String Nombre { get; set; }

        [DisplayName("Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime FechaHora { get; set; }

        [StringLength(245)]
        [DisplayName("Archivo")]
        public String Ruta { get; set; }

        [DisplayName("Versión")]
        public int? Version { get; set; }

        [DisplayName("Estado")]
        public int Estado { get; set; }

        [DisplayName("Pedido")]
        public int Pedido_ID { get; set; }

        [DefaultValue(1)]
        [DisplayName("Pedido")]
        [ForeignKey("Pedido_ID")]
        public virtual Pedido Pedido { get; set; }
    }
}
