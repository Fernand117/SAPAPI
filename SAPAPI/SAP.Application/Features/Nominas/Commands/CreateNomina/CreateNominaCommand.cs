using MediatR;
using SAP.Application.Features.Shared;
using SAP.Application.Interfaces;

namespace SAP.Application.Features.Nominas.Commands.CreateNomina;

public class CreateNominaCommand : IRequest<Response<int>>
{
    public int EmpleadoId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public decimal SalarioBase { get; set; }
    public decimal Bonificaciones { get; set; }
    public decimal Deducciones { get; set; }
    public decimal Total { get; set; }
}

public class CreateNominaCommandHandler : IRequestHandler<CreateNominaCommand, Response<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNominaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(CreateNominaCommand request, CancellationToken cancellationToken)
    {
        var nomina = new Domain.Entities.Nomina
        {
            EmpleadoId = request.EmpleadoId,
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            SalarioBase = request.SalarioBase,
            Bonificaciones = request.Bonificaciones,
            Deducciones = request.Deducciones,
            Total = request.Total
        };

        await _unitOfWork.Repository<Domain.Entities.Nomina>().AddAsync(nomina);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Response<int>
        {
            Succeeded = true,
            Data = nomina.Id,
            Message = "Nomina creada exitosamente"
        };
    }
}