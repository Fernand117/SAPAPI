using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Usuarios.Queries.GetUsuarioByUsername
{
    public class GetUsuarioByUsernameQueryHandler : IRequestHandler<GetUsuarioByUsernameQuery, UsuarioDto>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public GetUsuarioByUsernameQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> Handle(GetUsuarioByUsernameQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByUsernameAsync(request.Username);
            return _mapper.Map<UsuarioDto>(usuario);
        }
    }
} 