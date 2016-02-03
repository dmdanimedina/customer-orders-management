using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public enum TipoEstadoPedido
    {
        Inactivo = 0,
        Ingresado = 1,
        Revision = 2,
        Aprobado_Comercial = 3,
        Rechazado_Comercial = 4,
        Aprobado_Operaciones = 5,
        Rechazado_Operaciones = 6
    }

    public class EstadoPedido : Entity<int>
    {
        [StringLength(245)]
        [DisplayName("Nombre")]
        public String Nombre { get; set; }

        [DisplayName("Estado")]
        public int Estado { get; set; }

        [DisplayName("Pedidos")]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
