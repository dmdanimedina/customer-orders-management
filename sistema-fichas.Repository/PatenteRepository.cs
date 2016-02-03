using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sistema_fichas.Repository.Core;
using sistema_fichas.Business;
using System.Data.Entity;

namespace sistema_fichas.Repository
{
    public class PatenteRepository : GenericRepository<Patente>, IPatenteRepository
    {
        public PatenteRepository(DbContext _context)
            : base(_context)
        {
        }
        public IEnumerable<Pedido> GetAll(bool? OnlyActives)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patente> GetAllByClienteId(long Cliente_ID, bool? OnlyActives = true)
        {
            IEnumerable<Patente> resultado = null;
            int estado_activa = TipoEstadoPatente.Activa.GetHashCode();
            int estado_inactiva = TipoEstadoPatente.Inactiva.GetHashCode();
            resultado = FindBy(pd => pd.Cliente_ID == Cliente_ID);

            if (OnlyActives.Value == true)
                resultado.Where(pd => pd.Estado == estado_activa);

            return resultado;
        }

        public IEnumerable<Patente> GetAllByPedidoDetalleId(int PedidoDetalle_ID, bool? OnlyActives = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patente> GetAllByPedidoId(int Pedido_ID, bool? OnlyActives = true)
        {
            IEnumerable<Patente> resultado = null;
            int estado_activa = TipoEstadoPatente.Activa.GetHashCode();
            int estado_inactiva = TipoEstadoPatente.Inactiva.GetHashCode();

            return (OnlyActives.Value.Equals(true)) ? FindBy(pd => pd.Pedido_ID == Pedido_ID && pd.Estado == estado_activa) : FindBy(pd => pd.Pedido_ID == Pedido_ID);
            
        }

        public Patente GetById(int Id)
        {
            return FindBy(x => x.ID == Id).FirstOrDefault();
        }
    }
}
