using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Sucursales.Commands.UpdateSucursal
{
    public class UpdateSucursalCommandHandler : IRequestHandler<UpdateSucursalCommand, SucursalDto>
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public UpdateSucursalCommandHandler(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        public async Task<SucursalDto> Handle(UpdateSucursalCommand request, CancellationToken cancellationToken)
        {
            var sucursal = await _sucursalRepository.GetByIdAsync(request.Sucursal.SucursalId);
            if (sucursal == null)
                return null;

            sucursal.Nombre = request.Sucursal.Nombre;
            sucursal.Direccion = request.Sucursal.Direccion;
            sucursal.Telefono = request.Sucursal.Telefono;
            sucursal.Email = request.Sucursal.Email;
            sucursal.Activa = request.Sucursal.Activa;

            await _sucursalRepository.UpdateAsync(sucursal);
            return _mapper.Map<SucursalDto>(sucursal);
        }
    }
} 