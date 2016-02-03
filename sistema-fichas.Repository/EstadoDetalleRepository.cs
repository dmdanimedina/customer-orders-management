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
    public class EstadoDetalleRepository : GenericRepository<EstadoDetalle>, IEstadoDetalleRepository
    {
        public EstadoDetalleRepository(DbContext _context) 
            : base(_context) 
        {
        }

        public EstadoDetalle GetById(int Id) {
            return FindBy(x => x.ID == Id).FirstOrDefault();
        }

        public int getIdEstado(int Estado_ID)
        {
            var estado = FindBy(x => x.Estado == Estado_ID).FirstOrDefault();
            return (estado != null) ? estado.ID : 0;
        }
    }
}
