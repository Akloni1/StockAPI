using StockAPI.Domain.AggregationModels.DeliveryRequestAggregate;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Persistence.Implementation
{
    public class DeliveryRequestRepository : IDeliveryRequestRepository
    {
        public DeliveryRequestRepository()
        {
        }

        public Task<DeliveryRequest> CreateAsync(DeliveryRequest itemToCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryRequest> UpdateAsync(DeliveryRequest itemToUpdate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryRequest> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryRequest> FindByRequestNumberAsync(RequestNumber requestNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DeliveryRequest>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DeliveryRequest>> GetRequestsByStatusAsync(RequestStatus requestStatus, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}