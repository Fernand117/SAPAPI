using MediatR;

namespace SAP.Application.Features.Usuarios.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public int UsuarioId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
} 