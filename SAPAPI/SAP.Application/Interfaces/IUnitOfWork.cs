using SAP.Domain.Entities;

namespace SAP.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Commit(CancellationToken cancellationToken);
} 