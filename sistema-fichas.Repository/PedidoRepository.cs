using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DbContext _context) : base(_context) { }

        public Pedido GetById(int Id) {
            return _dbset
                .Include(p => p.Cliente)
                .Include(p => p.EstadoPedido)
                .Include(p => p.PedidosDetalle)
                .Include(p => p.UserProfile)
                .Include(p => p.Adjuntos)
                .Where(x => x.ID == Id)
                .FirstOrDefault();
        }

        public IEnumerable<Pedido> GetAllByClienteId(int Id, bool? OnlyActive = true)
        {
            return FindBy(x => x.Cliente_ID==Id);
        }

        public IEnumerable<Pedido> GetAll(bool? OnlyActives)
        {
            return (OnlyActives.Value) ? FindBy(x => x.EstadoPedido.Estado != null && x.EstadoPedido.Estado != 0) : GetAll();
        }

        public IEnumerable<Pedido> GetAllByCriteria(string attributeName, string attributeValue)
        {
            int attributeID = 0;
            Int32.TryParse(attributeValue, out attributeID);
            return FindBy(x => x.Cliente.NombreFantasia.Contains(attributeValue) || x.UserProfile.UserName.Contains(attributeValue) || x.Cliente.Rut.Contains(attributeValue) || x.EstadoPedido.Nombre.Contains(attributeValue) || x.ID ==  attributeID);
        }

        public IEnumerable<Pedido> GetAllOperaciones(string criteria, bool? OnlyActives)
        {
            int aprobado_comercial = TipoEstadoPedido.Aprobado_Comercial.GetHashCode();
            int aprobado_operaciones = TipoEstadoPedido.Aprobado_Operaciones.GetHashCode();
            int rechazado_operaciones = TipoEstadoPedido.Rechazado_Operaciones.GetHashCode();

            return FindBy(x => (
                x.EstadoPedido.Estado == aprobado_comercial ||
                x.EstadoPedido.Estado == aprobado_operaciones ||
                x.EstadoPedido.Estado == rechazado_operaciones
                ));
        }

    }
}
