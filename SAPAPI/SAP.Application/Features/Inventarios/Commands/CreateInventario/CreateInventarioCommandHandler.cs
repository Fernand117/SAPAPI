using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SAP.Application.DTOs;
using SAP.Application.Interfaces;
using SAP.Domain.Entities;

namespace SAP.Application.Features.Inventarios.Commands.CreateInventario
{
    public class CreateInventarioCommandHandler : IRequestHandler<CreateInventarioCommand, int>
    {
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IMapper _mapper;

        public CreateInventarioCommandHandler(IInventarioRepository inventarioRepository, IMapper mapper)
        {
            _inventarioRepository = inventarioRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInventarioCommand request, CancellationToken cancellationToken)
        {
            var inventario = _mapper.Map<Inventario>(request.Inventario);
            await _inventarioRepository.AddAsync(inventario);
            return inventario.InventarioId;
        }
    }
} 