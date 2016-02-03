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
    public class MonedaService : EntityService<Moneda>, IMonedaService
    {
        IUnitOfWork _unitOfWork;
        IMonedaRepository _monedaRepository;

        public MonedaService(IUnitOfWork unitOfWork, IMonedaRepository monedaRepository)
            : base(unitOfWork, monedaRepository)
        {
            _unitOfWork = unitOfWork;
            _monedaRepository = monedaRepository;
        }

        public Moneda GetById(int Id)
        {
            return _monedaRepository.GetById(Id);
        }
    }
}
