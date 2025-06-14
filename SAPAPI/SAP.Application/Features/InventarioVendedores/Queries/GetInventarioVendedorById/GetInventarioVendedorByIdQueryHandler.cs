using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.InventarioVendedores.Queries.GetInventarioVendedorById
{
    public class GetInventarioVendedorByIdQueryHandler : IRequestHandler<GetInventarioVendedorByIdQuery, InventarioVendedorDetalleDto>
    {
        private readonly IInventarioVendedorRepository _inventarioVendedorRepository;
        private readonly IMapper _mapper;

        public GetInventarioVendedorByIdQueryHandler(IInventarioVendedorRepository inventarioVendedorRepository, IMapper mapper)
        {
            _inventarioVendedorRepository = inventarioVendedorRepository;
            _mapper = mapper;
        }

        public async Task<InventarioVendedorDetalleDto> Handle(GetInventarioVendedorByIdQuery request, CancellationToken cancellationToken)
        {
            var inventario = await _inventarioVendedorRepository.GetByIdAsync(request.InventarioVendedorId);
            return _mapper.Map<InventarioVendedorDetalleDto>(inventario);
        }
    }
} 