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
    public class IndustriaService : EntityService<Industria>, IIndustriaService
    {
        IUnitOfWork _unitOfWork;
        IIndustriaRepository _industriaRepository;

        public IndustriaService(IUnitOfWork unitOfWork, IIndustriaRepository industriaRepository)
            : base(unitOfWork, industriaRepository) {
                _unitOfWork = unitOfWork;
                _industriaRepository = industriaRepository;
        }

        public Industria GetById(int Id) {
            return _industriaRepository.GetById(Id);
        }
    }
}
