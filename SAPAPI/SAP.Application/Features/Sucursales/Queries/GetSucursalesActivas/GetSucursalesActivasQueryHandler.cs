using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Sucursales.Queries.GetSucursalesActivas
{
    public class GetSucursalesActivasQueryHandler : IRequestHandler<GetSucursalesActivasQuery, IEnumerable<SucursalDto>>
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public GetSucursalesActivasQueryHandler(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SucursalDto>> Handle(GetSucursalesActivasQuery request, CancellationToken cancellationToken)
        {
            var sucursales = await _sucursalRepository.GetAllAsync();
            var sucursalesActivas = sucursales.Where(s => s.Activa);
            return _mapper.Map<IEnumerable<SucursalDto>>(sucursalesActivas);
        }
    }
} 