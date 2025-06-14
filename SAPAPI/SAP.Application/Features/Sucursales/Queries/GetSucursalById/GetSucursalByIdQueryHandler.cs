using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Sucursales.Queries.GetSucursalById
{
    public class GetSucursalByIdQueryHandler : IRequestHandler<GetSucursalByIdQuery, SucursalDto>
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public GetSucursalByIdQueryHandler(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        public async Task<SucursalDto> Handle(GetSucursalByIdQuery request, CancellationToken cancellationToken)
        {
            var sucursal = await _sucursalRepository.GetByIdAsync(request.SucursalId);
            return _mapper.Map<SucursalDto>(sucursal);
        }
    }
} 