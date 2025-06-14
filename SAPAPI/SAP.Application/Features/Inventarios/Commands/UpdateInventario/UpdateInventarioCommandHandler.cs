using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Domain.Interfaces;
using SAP.Domain.Entities;

namespace SAP.Application.Features.Inventarios.Commands.UpdateInventario
{
    public class UpdateInventarioCommandHandler : IRequestHandler<UpdateInventarioCommand, bool>
    {
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IMapper _mapper;

        public UpdateInventarioCommandHandler(IInventarioRepository inventarioRepository, IMapper mapper)
        {
            _inventarioRepository = inventarioRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateInventarioCommand request, CancellationToken cancellationToken)
        {
            var inventario = await _inventarioRepository.GetByIdAsync(request.Inventario.InventarioId);
            if (inventario == null)
                return false;

            _mapper.Map(request.Inventario, inventario);
            await _inventarioRepository.UpdateAsync(inventario);
            return true;
        }
    }
} 