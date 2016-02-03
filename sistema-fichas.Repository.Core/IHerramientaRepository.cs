using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Repository.Core
{
    public interface IHerramientaRepository : IGenericRepository<Herramienta>
    {
        Herramienta GetById(int Id);
    }
}
