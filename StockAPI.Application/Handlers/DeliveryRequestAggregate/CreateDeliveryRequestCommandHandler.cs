using MediatR;
using StockAPI.Application.Commands.CreateDeliveryRequest;
using StockAPI.Domain.AggregationModels.DeliveryRequestAggregate;
using StockAPI.Domain.AggregationModels.ValueObjects;
using StockAPI.Persistence.Contracts;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Application.Handlers.DeliveryRequestAggregate;

public class CreateDeliveryRequestCommandHandler : IRequestHandler<CreateDeliveryRequestCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        
        public CreateDeliveryRequestCommandHandler(IDeliveryRequestRepository deliveryRequestRepository,
            IUnitOfWork unitOfWork)
        {
            _deliveryRequestRepository = deliveryRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateDeliveryRequestCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);
            var deliveryRequest = new DeliveryRequest(
                null,
                RequestStatus.InWork,
                request.Items.Select(it => new Sku(it.Sku)).ToList());

            // Отправка запроса в сторонний сервис сервис для получения номера заказа но поставку
            
            // TODO
          
            // Сбор информации
            
            var result = await _deliveryRequestRepository.CreateAsync(deliveryRequest, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Id;
        }
    }