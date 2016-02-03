using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository
{
    public class PedidoDetalleRepository : GenericRepository<PedidoDetalle>, IPedidoDetalleRepository
    {
        public PedidoDetalleRepository(DbContext _context) : base(_context) { }

        public PedidoDetalle GetById(int Id) {
            
            return FindBy(x => x.ID == Id).FirstOrDefault();
        }

        public IEnumerable<PedidoDetalle> GetAllByPedidoId(int Pedido_ID, int? TipoPedidoDetalle_ID, bool? OnlyActives=true)
        {
            IEnumerable<PedidoDetalle> resultado = null;
            int estado_activo = TipoEstadoDetalle.Activo.GetHashCode();
            int estado_inactiva = TipoEstadoDetalle.Inactivo.GetHashCode();
            if (TipoPedidoDetalle_ID == null){
                resultado= FindBy(pd => pd.Pedido_ID == Pedido_ID);
            }else {
                resultado = _dbset
                    .Include(p => p.Modalidad)
                    .Include(p => p.Herramienta)
                    .Include(p => p.Catalogo)
                    .Include(p => p.Moneda)
                    .Include(p => p.EstadoDetalle)
                    .Include(p => p.Pedido)
                    .Where(pd => pd.Pedido_ID == Pedido_ID && pd.Tipo == TipoPedidoDetalle_ID && pd.EstadoDetalle.Estado != estado_inactiva).AsEnumerable();
            }

            if (OnlyActives.Value == true)
                resultado.Where(pd => pd.EstadoDetalle.Estado != estado_inactiva);

            return resultado;
        }

        public IEnumerable<PedidoDetalle> GetActividadesNoFinalizadas(int Pedido_ID)
        {
            int estado_finalizado = TipoEstadoDetalle.Finalizado.GetHashCode();
            int estado_inactiva = TipoEstadoDetalle.Inactivo.GetHashCode();
            int estado_aprobado_operaciones = TipoEstadoPedido.Aprobado_Operaciones.GetHashCode();
            int tipo_actividad = TipoPedidoDetalle.Actividad.GetHashCode();

            return FindBy(pd => pd.Pedido_ID == Pedido_ID && pd.Tipo == tipo_actividad && pd.EstadoDetalle.Estado != estado_finalizado && pd.EstadoDetalle.Estado != estado_inactiva && pd.Pedido.EstadoPedido.Estado == estado_aprobado_operaciones);
        }
    }
}
