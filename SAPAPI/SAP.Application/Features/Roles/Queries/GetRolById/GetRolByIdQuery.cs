using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Roles.Queries.GetRolById
{
    public class GetRolByIdQuery : IRequest<RolDto>
    {
        public int RolId { get; set; }
    }

    public class GetRolByIdQueryHandler : IRequestHandler<GetRolByIdQuery, RolDto>
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public GetRolByIdQueryHandler(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<RolDto> Handle(GetRolByIdQuery request, CancellationToken cancellationToken)
        {
            var rol = await _rolRepository.GetByIdAsync(request.RolId);
            if (rol == null)
                throw new Exception($"No se encontró el rol con ID {request.RolId}");

            return _mapper.Map<RolDto>(rol);
        }
    }
} 