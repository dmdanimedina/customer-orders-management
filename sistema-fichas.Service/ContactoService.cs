using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using sistema_fichas.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Service
{
    public class ContactoService : EntityService<Contacto>, IContactoService
    {
        IUnitOfWork _unitOfWork;
        IContactoRepository _contactoRepository;

        public ContactoService(IUnitOfWork unitOfWork, IContactoRepository contactoRepository) 
            : base(unitOfWork, contactoRepository) 
        {
            _unitOfWork = unitOfWork;
            _contactoRepository = contactoRepository;
        }

        public Contacto GetById(int Id) {
            return _contactoRepository.GetById(Id);
        }

        public IEnumerable<Contacto> GetAllByClienteId(int Id, bool? OnlyActives = true) {
            return _contactoRepository.GetAllByClienteId(Id, OnlyActives);
        }

        public IEnumerable<Contacto> GetAllByCriteria(string searchCriteria, string ContactoAttribute, bool? OnlyActives = true) 
        {
            if (String.IsNullOrEmpty(searchCriteria))
                return _contactoRepository.GetAll(OnlyActives);
            else {
                var resultado = _contactoRepository.GetAllByCriteria(ContactoAttribute, searchCriteria);
                return resultado;

            } 
            
        }

    }
}
