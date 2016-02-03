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
    public class ClienteService : EntityService<Cliente>, IClienteService
    {
        IUnitOfWork _unitOfWork;
        IClienteRepository _clienteRepository;

        public ClienteService(IUnitOfWork unitOfWork, IClienteRepository clienteRepository)
            : base(unitOfWork, clienteRepository) 
        {
            _unitOfWork = unitOfWork;
            _clienteRepository = clienteRepository;
        }

        public Cliente GetById(long Id)
        {
            return _clienteRepository.GetById(Id);
        }

        public IEnumerable<Cliente> GetAllByCriteria(string searchCriteria, string ContactoAttribute, bool? OnlyActives = true) {
            IEnumerable<Cliente> resultado = null;
            resultado = (String.IsNullOrEmpty(searchCriteria)) ? _clienteRepository.GetAll(OnlyActives.Value) : _clienteRepository.GetAllByCriteria(ContactoAttribute, searchCriteria);
            return resultado;
        }

        public IEnumerable<Cliente> GetAllWithPedidos(int? EstadoPedido = 0)
        {
            return _clienteRepository.GetAllWithPedidos(EstadoPedido.Value);
        }
    }
}
