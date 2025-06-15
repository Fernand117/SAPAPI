using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.Nominas.Commands.UpdateNomina;

public class UpdateNominaCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public decimal SalarioBase { get; set; }
    public decimal Bonificaciones { get; set; }
    public decimal Deducciones { get; set; }
    public decimal Total { get; set; }
}

public class UpdateNominaCommandHandler : IRequestHandler<UpdateNominaCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNominaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(UpdateNominaCommand request, CancellationToken cancellationToken)
    {
        var nomina = await _unitOfWork.Repository<Domain.Entities.Nomina>().GetByIdAsync(request.Id);
        
        if (nomina == null)
        {
            return new Response<int>
            {
                Succeeded = false,
                Message = "Nomina no encontrada"
            };
        }

        nomina.EmpleadoId = request.EmpleadoId;
        nomina.FechaInicio = request.FechaInicio;
        nomina.FechaFin = request.FechaFin;
        nomina.SalarioBase = request.SalarioBase;
        nomina.Bonificaciones = request.Bonificaciones;
        nomina.Deducciones = request.Deducciones;
        nomina.Total = request.Total;

        await _unitOfWork.Repository<Domain.Entities.Nomina>().UpdateAsync(nomina);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = nomina.Id,
            Message = "Nomina actualizada exitosamente"
        };
    }
}