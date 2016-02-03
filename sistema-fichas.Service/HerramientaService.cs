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
    public class HerramientaService : EntityService<Herramienta>, IHerramientaService
    {
        IUnitOfWork _unitOfWork;
        IHerramientaRepository _herramientaRepository;

        public HerramientaService(IUnitOfWork unitOfWork, IHerramientaRepository herramientaRepository)
            : base(unitOfWork, herramientaRepository) 
        {
            _unitOfWork = unitOfWork;
            _herramientaRepository = herramientaRepository;
        }

        public Herramienta GetById(int Id) {
            return _herramientaRepository.GetById(Id);
        }
    }
}
