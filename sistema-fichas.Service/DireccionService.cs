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
    public class DireccionService : EntityService<Direccion>, IDireccionService
    {
        IUnitOfWork _unitOfWork;
        IDireccionRepository _direccionRepository;

        public DireccionService(IUnitOfWork unitOfWork, IDireccionRepository direccionRepository) 
            : base(unitOfWork,direccionRepository)
        {
            _unitOfWork = unitOfWork;
            _direccionRepository = direccionRepository;
        }

        public Direccion GetById(int Id)
        {
            return _direccionRepository.GetById(Id);
        }
    }
}
