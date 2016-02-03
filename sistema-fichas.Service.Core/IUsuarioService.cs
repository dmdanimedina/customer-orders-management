using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sistema_fichas.Business;


namespace sistema_fichas.Service.Core
{
    public interface IUsuarioService : IEntityService<UserProfile>
    {
        UserProfile GetById(int Id);
    }
}
