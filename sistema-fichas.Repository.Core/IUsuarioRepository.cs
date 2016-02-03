using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sistema_fichas.Business;

namespace sistema_fichas.Repository.Core
{
    public interface IUsuarioRepository : IGenericRepository<UserProfile>
    {
        UserProfile GetById(int Id);
    }
}
