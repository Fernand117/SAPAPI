using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.Inventarios.Queries.GetInventarioById
{
    public class GetInventarioByIdQueryHandler : IRequestHandler<GetInventarioByIdQuery, InventarioDto>
    {
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IMapper _mapper;

        public GetInventarioByIdQueryHandler(IInventarioRepository inventarioRepository, IMapper mapper)
        {
            _inventarioRepository = inventarioRepository;
            _mapper = mapper;
        }

        public async Task<InventarioDto> Handle(GetInventarioByIdQuery request, CancellationToken cancellationToken)
        {
            var inventario = await _inventarioRepository.GetByIdAsync(request.Id);
            return _mapper.Map<InventarioDto>(inventario);
        }
    }
} 