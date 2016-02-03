using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using System.Data.Entity;

namespace sistema_fichas.Repository
{
    public class UsuarioRepository : GenericRepository<UserProfile>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext _context) : base(_context) { }

        public UserProfile GetById(int Id)
        {
            return FindBy(x => x.UserId == Id).FirstOrDefault();
        }

    }
}
