using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Ventas.Commands.CreateVenta
{
    public class CreateVentaCommandHandler : IRequestHandler<CreateVentaCommand, VentaDto>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public CreateVentaCommandHandler(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        public async Task<VentaDto> Handle(CreateVentaCommand request, CancellationToken cancellationToken)
        {
            var venta = _mapper.Map<Venta>(request.Venta);
            venta.EmpleadoId = request.Venta.EmpleadoId;
            venta.Fecha = DateTime.Now;
            venta.Estado = "Pendiente";

            var detalles = _mapper.Map<ICollection<DetalleVenta>>(request.Venta.Detalles);
            await _ventaRepository.RegistrarVentaAsync(venta, detalles);

            return _mapper.Map<VentaDto>(venta);
        }
    }
} 