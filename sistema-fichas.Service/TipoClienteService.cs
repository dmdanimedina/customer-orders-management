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
    public class TipoClienteService : EntityService<TipoCliente>, ITipoClienteService
    {
        IUnitOfWork _unitOfWork;
        ITipoClienteRepository _tipoClienteRepository;

        public TipoClienteService(IUnitOfWork unitOfWork, ITipoClienteRepository tipoClienteRepository)
            : base(unitOfWork, tipoClienteRepository)
        {
            _unitOfWork = unitOfWork;
            _tipoClienteRepository = tipoClienteRepository;
        }

        public TipoCliente GetById(int Id)
        {
            return _tipoClienteRepository.GetById(Id);
        }

    }
}
