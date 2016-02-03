using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sistema_fichas.Business;
using sistema_fichas.Repository.Core;
using sistema_fichas.Service.Core;

namespace sistema_fichas.Service
{
    public class UsuarioService : EntityService<UserProfile>, IUsuarioService
    {
        IUnitOfWork _unitOfWork;
        IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository)
            : base(unitOfWork, usuarioRepository)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
        }

        public UserProfile GetById(int Id)
        {
            return _usuarioRepository.GetById(Id);
        }

        public IEnumerable<UserProfile> GetAllEjecutivos(int Id, bool? OnlyActive = true)
        {
            return _usuarioRepository.GetAll();
        }
    }
}
