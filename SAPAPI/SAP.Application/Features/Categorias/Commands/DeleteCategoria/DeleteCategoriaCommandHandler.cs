using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Categorias.Commands.DeleteCategoria
{
    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, bool>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public DeleteCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(request.CategoriaId);
            if (categoria == null)
                return false;

            await _categoriaRepository.DeleteAsync(categoria);
            return true;
        }
    }
} 