namespace StockAPI.Persistence.Contracts.Common;

public interface IUnitOfWork : IDisposable
{
    ValueTask StartTransaction(CancellationToken token);
        
    Task SaveChangesAsync(CancellationToken cancellationToken);
}