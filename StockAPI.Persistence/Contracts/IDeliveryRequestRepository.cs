using StockAPI.Domain.AggregationModels.DeliveryRequestAggregate;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Persistence.Contracts;

/// <summary>
/// Репозиторий для управления сущностью <see cref="DeliveryRequest"/>
/// </summary>
public interface IDeliveryRequestRepository : IRepository<DeliveryRequest>
{
    Task<DeliveryRequest> CreateAsync(DeliveryRequest itemToCreate, CancellationToken cancellationToken);

    Task<DeliveryRequest> UpdateAsync(DeliveryRequest itemToUpdate,
        CancellationToken cancellationToken);

    Task<DeliveryRequest> FindByIdAsync(int id, CancellationToken cancellationToken);

    Task<DeliveryRequest> FindByRequestNumberAsync(
        RequestNumber requestNumber,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<DeliveryRequest>> GetAllRequestsAsync(CancellationToken cancellationToken);

    Task<IReadOnlyCollection<DeliveryRequest>> GetRequestsByStatusAsync(RequestStatus requestStatus,
        CancellationToken cancellationToken);
}