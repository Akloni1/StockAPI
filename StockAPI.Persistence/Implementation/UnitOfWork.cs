using MediatR;
using StockAPI.Persistence.Contracts.Common;
using StockAPI.Persistence.Infrastructure;

namespace StockAPI.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        
        // TODO: Контекст, фабрика
        //private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory = null;
        //private NpgsqlTransaction _npgsqlTransaction;
        
        private readonly IPublisher _publisher;
        private readonly IChangeTracker _changeTracker;

        public UnitOfWork(
            IPublisher publisher,
            IChangeTracker changeTracker)
        {
            _publisher = publisher;
            _changeTracker = changeTracker;
        }

        public async ValueTask StartTransaction(CancellationToken token)
        {
            // if (_npgsqlTransaction is not null)
            // {
            //     return;
            // }
            // var connection = await _dbConnectionFactory.CreateConnection(token);
            // _npgsqlTransaction = await connection.BeginTransactionAsync(token);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            // if (_npgsqlTransaction is null)
            // {
            //     throw new NoActiveTransactionStartedException();
            // }

            var domainEvents = new Queue<INotification>(
                _changeTracker.TrackedEntities
                    .SelectMany(x =>
                    {
                        var events = x.Value.DomainEvents.ToList();
                        x.Value.ClearDomainEvents();
                        return events;
                    }));

            // Можно отправлять все и сразу через Task.WhenAll.
            while (domainEvents.TryDequeue(out var notification))
            {
                dynamic not = (dynamic)notification;
                await _publisher.Publish(not, cancellationToken);
            }

            //await _npgsqlTransaction.CommitAsync(cancellationToken);
        }

        void IDisposable.Dispose()
        {
            // _npgsqlTransaction?.Dispose();
            // _dbConnectionFactory?.Dispose();
        }
    }
}