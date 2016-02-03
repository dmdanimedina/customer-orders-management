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
    public class TipoClienteRepository : GenericRepository<TipoCliente>, ITipoClienteRepository
    {
        public TipoClienteRepository(DbContext _context) : base(_context) { }

        public TipoCliente GetById(int Id) {
            return FindBy(x => x.ID == Id).FirstOrDefault();
        }
    }
}
