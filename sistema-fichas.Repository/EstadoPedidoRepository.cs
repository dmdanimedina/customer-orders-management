using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using System.Data.Entity;

namespace sistema_fichas.Repository
{
    public class EstadoPedidoRepository : GenericRepository<EstadoPedido>, IEstadoPedidoRepository
    {
        public EstadoPedidoRepository(DbContext _context) 
            : base(_context) { }

        public EstadoPedido GetById(int Id) {
            return FindBy(x => x.ID == Id).FirstOrDefault();
        }

        public int getIdEstado(int Estado) {
            var estado =  FindBy(x => x.Estado == Estado).FirstOrDefault();
            return (estado != null) ? estado.ID : 0;
        }
    }
}
