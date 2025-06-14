using MediatR;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Atributos.Commands.DeleteAtributo
{
    public class DeleteAtributoCommand : IRequest<bool>
    {
        public int AtributoId { get; set; }
    }

    public class DeleteAtributoCommandHandler : IRequestHandler<DeleteAtributoCommand, bool>
    {
        private readonly IGenericRepository<Atributo> _atributoRepository;

        public DeleteAtributoCommandHandler(IGenericRepository<Atributo> atributoRepository)
        {
            _atributoRepository = atributoRepository;
        }

        public async Task<bool> Handle(DeleteAtributoCommand request, CancellationToken cancellationToken)
        {
            var atributo = await _atributoRepository.GetByIdAsync(request.AtributoId);
            if (atributo == null)
                throw new Exception($"No se encontró el atributo con ID {request.AtributoId}");

            return await _atributoRepository.DeleteAsync(atributo);
        }
    }
} 