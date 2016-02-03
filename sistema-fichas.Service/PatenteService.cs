using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sistema_fichas.Service.Core;
using sistema_fichas.Business;
using sistema_fichas.Repository.Core;

namespace sistema_fichas.Service
{
    public class PatenteService : EntityService<Patente>, IPatenteService
    {
        IUnitOfWork _unitOfWork;
        IPatenteRepository _patenteRepository;

        public PatenteService(IUnitOfWork unitOfWork, IPatenteRepository patenteRepository)
            : base(unitOfWork, patenteRepository)
        {
            _unitOfWork = unitOfWork;
            _patenteRepository = patenteRepository;
        }

        public Patente GetById(int Id)
        {
            return _patenteRepository.GetById(Id);
        }

        public IEnumerable<Patente> GetAllByPedidoId(int Pedido_ID, bool? OnlyActives = true)
        {
            return _patenteRepository.GetAllByPedidoId(Pedido_ID);
        }

        public IEnumerable<Patente> GetAllByClienteId(long Cliente_ID, bool? OnlyActives = true)
        {
            return _patenteRepository.GetAllByClienteId(Cliente_ID, OnlyActives);
        }

        public IEnumerable<Patente> GetAllByPedidoDetalleId(int PedidoDetalle_ID, bool? OnlyActives = true)
        {
            return _patenteRepository.GetAllByPedidoDetalleId(PedidoDetalle_ID, OnlyActives);
        }

        public IEnumerable<Pedido> GetAll(bool? OnlyActives)
        {
            return _patenteRepository.GetAll(OnlyActives);
        }

        public void ValidarPatente(string patente, string gps_id){

        }
    }
}
