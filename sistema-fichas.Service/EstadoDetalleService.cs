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
    public class EstadoDetalleService : EntityService<EstadoDetalle>, IEstadoDetalleService
    {
        IUnitOfWork _unitOfWork;
        IEstadoDetalleRepository _estadoDetalleRepository;
        
        public EstadoDetalleService(IUnitOfWork unitOfWork, IEstadoDetalleRepository estadoDetalleRepository) 
            : base(unitOfWork, estadoDetalleRepository) {
                _unitOfWork = unitOfWork;
                _estadoDetalleRepository = estadoDetalleRepository;
        }

        public EstadoDetalle GetById(int Id)
        {
            return _estadoDetalleRepository.GetById(Id);
        }

        public int GetIdEstadoDeshabilitado() {
            return _estadoDetalleRepository.getIdEstado(TipoEstadoDetalle.Deshabilitado.GetHashCode());
        }

        public int GetIdEstadoInicial()
        {
            return _estadoDetalleRepository.getIdEstado(TipoEstadoDetalle.Activo.GetHashCode());
        }

        public int GetIdEstadoInactivo() 
        {
            return _estadoDetalleRepository.getIdEstado(TipoEstadoDetalle.Inactivo.GetHashCode());
        }

        public int GetIdEstado(int Estado_ID)
        {
            return _estadoDetalleRepository.getIdEstado(Estado_ID);
        }
    }
}
