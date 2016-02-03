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
    public class EstadoPedidoService : EntityService<EstadoPedido>, IEstadoPedidoService
    {
        IUnitOfWork _unitOfWork;
        IEstadoPedidoRepository _estadoPedidoRepository;

        public EstadoPedidoService(IUnitOfWork unitOfWork, IEstadoPedidoRepository estadoPedidoRepository) 
            : base(unitOfWork, estadoPedidoRepository) {
                _unitOfWork = unitOfWork;
                _estadoPedidoRepository = estadoPedidoRepository;
        }

        public EstadoPedido GetById(int Id) 
        {
            return _estadoPedidoRepository.GetById(Id);
        }

        public int GetIdEstadoInicial()
        {
            return _estadoPedidoRepository.getIdEstado(TipoEstadoPedido.Ingresado.GetHashCode());
        }

        public int GetIdEstadoInactivo()
        { 
            return _estadoPedidoRepository.getIdEstado(TipoEstadoPedido.Inactivo.GetHashCode());
        }

        public int GetIdEstadoRevisionComercial() 
        { 
            return _estadoPedidoRepository.getIdEstado(TipoEstadoPedido.Revision.GetHashCode());
        }

        public int GetIdEstadoAprobadoComercial() 
        { 
            return _estadoPedidoRepository.getIdEstado(TipoEstadoPedido.Aprobado_Comercial.GetHashCode());
        }

        public int GetIdEstadoRechazadoComercial() 
        { 
            return _estadoPedidoRepository.getIdEstado(TipoEstadoPedido.Rechazado_Comercial.GetHashCode());
        }

        public int GetIdEstado(int Estado_ID) {
            return _estadoPedidoRepository.getIdEstado(Estado_ID);
        }
    }
}
