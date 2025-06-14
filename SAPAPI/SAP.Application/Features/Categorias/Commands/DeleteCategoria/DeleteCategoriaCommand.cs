using MediatR;

namespace SAP.Application.Features.Categorias.Commands.DeleteCategoria
{
    public class DeleteCategoriaCommand : IRequest<bool>
    {
        public int CategoriaId { get; set; }
    }
} 