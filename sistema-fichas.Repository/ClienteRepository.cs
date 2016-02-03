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
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbContext _context)
            : base(_context)
        { }

        public Cliente GetById(long Id) {
            return FindBy(x => x.ID == Id).FirstOrDefault();
        }

        public IEnumerable<Cliente> GetAll(bool? OnlyActives)
        {
            if (OnlyActives.Value)
                return FindBy(x => x.Estado != 0);
            else
                return GetAll();
        }

        public IEnumerable<Cliente> GetAllWithPedidos(int EstadoPedido)
        {
            int aprobado_operaciones = TipoEstadoPedido.Aprobado_Operaciones.GetHashCode();
            int estado_inactivo = TipoEstadoDetalle.Inactivo.GetHashCode();
            int estado_finalizado = TipoEstadoDetalle.Finalizado.GetHashCode();
            int tipo_actividad = TipoPedidoDetalle.Actividad.GetHashCode();
            return FindBy(x => x.Pedidos.Where(y => y.EstadoPedido.Estado == aprobado_operaciones && y.PedidosDetalle.Where(z => z.EstadoDetalle.Estado != estado_inactivo && z.EstadoDetalle.Estado != estado_finalizado && z.Tipo == tipo_actividad).Count() > 0).Count() > 0);
        }

        public IEnumerable<Cliente> GetAllByCriteria(string attributeName, string attributeValue)
        {
            return FindBy(x => x.NombreFantasia.Contains(attributeValue) || x.RazonSocial.Contains(attributeValue) || x.Rut.Contains(attributeValue) || x.Usuario.UserName.Contains(attributeValue));
        }
    }
}
