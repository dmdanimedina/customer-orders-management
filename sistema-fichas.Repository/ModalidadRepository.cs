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
    public class ModalidadRepository : GenericRepository<Modalidad>, IModalidadRepository
    {
        public ModalidadRepository(DbContext _context) 
            : base(_context) { }

        public Modalidad GetById(int Id) {
            return FindBy(x => x.ID == Id).FirstOrDefault();
        }
    }
}
