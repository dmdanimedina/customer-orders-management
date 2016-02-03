using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using sistema_fichas.Service.Core;

namespace sistema_fichas.Service
{
    public class ModalidadService : EntityService<Modalidad>, IModalidadService
    {
        IUnitOfWork _unitOfWork;
        IModalidadRepository _modalidadRepository;

        public ModalidadService(IUnitOfWork unitOfWork, IModalidadRepository modalidadRepository) : 
            base(unitOfWork,modalidadRepository)
        {
            _unitOfWork = unitOfWork;
            _modalidadRepository = modalidadRepository;
        }

        public Modalidad GetById(int Id)
        {
            return _modalidadRepository.GetById(Id);
        }
    }
}
