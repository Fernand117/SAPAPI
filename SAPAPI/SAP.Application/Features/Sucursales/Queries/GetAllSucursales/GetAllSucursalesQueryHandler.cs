using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Sucursales.Queries.GetAllSucursales
{
    public class GetAllSucursalesQueryHandler : IRequestHandler<GetAllSucursalesQuery, IEnumerable<SucursalDto>>
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public GetAllSucursalesQueryHandler(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SucursalDto>> Handle(GetAllSucursalesQuery request, CancellationToken cancellationToken)
        {
            var sucursales = await _sucursalRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SucursalDto>>(sucursales);
        }
    }
} 