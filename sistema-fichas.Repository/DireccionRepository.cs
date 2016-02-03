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
    public class DireccionRepository : GenericRepository<Direccion>, IDireccionRepository
    {
        public DireccionRepository(DbContext _context)
            : base(_context)
        {
        
        }

        public Direccion GetById(int id)
        {
            return FindBy(x => x.ID == id).FirstOrDefault();
        }
    }
}
