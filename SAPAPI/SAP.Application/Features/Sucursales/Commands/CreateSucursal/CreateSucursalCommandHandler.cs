using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Sucursales.Commands.CreateSucursal
{
    public class CreateSucursalCommandHandler : IRequestHandler<CreateSucursalCommand, SucursalDto>
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public CreateSucursalCommandHandler(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        public async Task<SucursalDto> Handle(CreateSucursalCommand request, CancellationToken cancellationToken)
        {
            var sucursal = _mapper.Map<Sucursal>(request.Sucursal);
            sucursal.FechaApertura = DateTime.UtcNow;
            sucursal.Activa = true;
            var sucursalCreada = await _sucursalRepository.AddAsync(sucursal);
            return _mapper.Map<SucursalDto>(sucursalCreada);
        }
    }
} 