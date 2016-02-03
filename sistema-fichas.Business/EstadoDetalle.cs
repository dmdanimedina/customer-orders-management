using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public enum TipoEstadoDetalle
    {
        Inactivo = 0,
        Activo = 1,
        Agendado = 2,
        Parcial = 3,
        Finalizado = 4,
        Deshabilitado = 5,


    }

    public class EstadoDetalle : Entity<int>
    {
        [StringLength(245)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Estado")]
        public int Estado { get; set; }

        [DisplayName("Pedido")]
        public virtual ICollection<PedidoDetalle> PedidosDetalle { get; set; }
    }
}
