using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Usuarios.Queries.GetUsuariosActivos
{
    public class GetUsuariosActivosQueryHandler : IRequestHandler<GetUsuariosActivosQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public GetUsuariosActivosQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(GetUsuariosActivosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuariosActivos = usuarios.Where(u => u.Activo);
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuariosActivos);
        }
    }
} 