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
    public class CatalogoRepository : GenericRepository<Catalogo>, ICatalogoRepository
    {
        public CatalogoRepository(DbContext _context)
            : base(_context)
        {
        }

        public Catalogo GetById(int id)
        {
            return FindBy(x => x.ID == id).FirstOrDefault();
        }
    }
}
