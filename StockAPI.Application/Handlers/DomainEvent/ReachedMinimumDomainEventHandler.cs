using MediatR;
using StockAPI.Domain.AggregationModels.DeliveryRequestAggregate;
using StockAPI.Domain.Events;
using StockAPI.Persistence.Contracts;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Application.Handlers.DomainEvent
{
    public class ReachedMinimumDomainEventHandler : INotificationHandler<ReachedMinimumStockItemsNumberDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        
        public ReachedMinimumDomainEventHandler(IUnitOfWork unitOfWork,
            IDeliveryRequestRepository deliveryRequestRepository)
        {
            _unitOfWork = unitOfWork;
            _deliveryRequestRepository = deliveryRequestRepository;
        }

        public async Task Handle(ReachedMinimumStockItemsNumberDomainEvent notification,
            CancellationToken cancellationToken)
        {
            var deliveryRequest = new DeliveryRequest(
                null,
                RequestStatus.InWork,
                new[] { notification.StockItemSku });

            // Отправка запроса в сервис Supply для получения номера заказа но поставку
            
            // TODO
           
            // Сбор информации
            
            var result = await _deliveryRequestRepository.CreateAsync(deliveryRequest, cancellationToken);
        }
    }
}