using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Usuarios.Queries.SearchUsuarios
{
    public class SearchUsuariosQueryHandler : IRequestHandler<SearchUsuariosQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public SearchUsuariosQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(SearchUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuariosFiltrados = usuarios.Where(u => 
                u.Username.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                u.Email.Contains(request.SearchTerm, System.StringComparison.OrdinalIgnoreCase));
            
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuariosFiltrados);
        }
    }
} 