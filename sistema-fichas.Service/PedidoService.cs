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
    public class PedidoService : EntityService<Pedido>, IPedidoService
    {
        IUnitOfWork _unitOfWork;
        IPedidoRepository _pedidoRepository;

        public PedidoService(IUnitOfWork unitOfWork, IPedidoRepository pedidoRepository)
            : base(unitOfWork, pedidoRepository)
        {
            _unitOfWork = unitOfWork;
            _pedidoRepository = pedidoRepository;
        }

        public Pedido GetById(int Id)
        {
            return _pedidoRepository.GetById(Id);
        }

        public IEnumerable<Pedido> GetAllByClienteId(int Id, bool? OnlyActive = true)
        {
            return _pedidoRepository.GetAllByClienteId(Id);
        }

        public IEnumerable<Pedido> GetAllByCriteria(string searchCriteria, string ContactoAttribute, bool? OnlyActives = true)
        {
            IEnumerable<Pedido> resultado = null;
            resultado = (String.IsNullOrEmpty(searchCriteria)) ? _pedidoRepository.GetAll(OnlyActives.Value) : _pedidoRepository.GetAllByCriteria(ContactoAttribute, searchCriteria);
            return resultado;
        }

        public IEnumerable<Pedido> GetAllOperaciones(string criteria, bool? OnlyActives = true) 
        {
            return _pedidoRepository.GetAllOperaciones(criteria, OnlyActives.Value);
            
        }

    }
}
