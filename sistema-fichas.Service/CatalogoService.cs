using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using sistema_fichas.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service
{
    public class CatalogoService : EntityService<Catalogo>, ICatalogoService
    {
        IUnitOfWork _unitOfWork;
        ICatalogoRepository _catalogoRepository;

        public CatalogoService(IUnitOfWork unitOfWork, ICatalogoRepository catalogoRepository) 
            : base(unitOfWork, catalogoRepository) 
        {
            _unitOfWork = unitOfWork;
            _catalogoRepository = catalogoRepository;
        }

        public Catalogo GetById(int Id) {
            return _catalogoRepository.GetById(Id);
        }

        public IEnumerable<Catalogo> GetAllByType(int Type)
        {
            return _catalogoRepository.FindBy(x => x.Tipo == Type && x.Estado == 1);
        }
    }
}
