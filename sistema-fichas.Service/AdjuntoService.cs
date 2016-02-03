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
    public class AdjuntoService : EntityService<Adjunto>, IAdjuntoService
    {
        IUnitOfWork _unitOfWork;
        IAdjuntoRepository _adjuntoRepository;

        public AdjuntoService(IUnitOfWork unitOfWork, IAdjuntoRepository adjuntoRepository)
            : base(unitOfWork, adjuntoRepository)
        {
            _unitOfWork = unitOfWork;
            _adjuntoRepository = adjuntoRepository;
        }

        public Adjunto GetById(int Id)
        {
            return _adjuntoRepository.GetById(Id);
        }
    }
}
