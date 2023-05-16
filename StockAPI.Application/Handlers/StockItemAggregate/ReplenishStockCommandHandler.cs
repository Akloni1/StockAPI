using MediatR;
using StockAPI.Application.Commands.ReplenishStock;
using StockAPI.Application.Models;
using StockAPI.Domain.AggregationModels.DeliveryRequestAggregate;
using StockAPI.Domain.AggregationModels.ValueObjects;
using StockAPI.Persistence.Contracts;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class ReplenishStockCommandHandler : IRequestHandler<ReplenishStockCommand, Unit>
    {
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IDeliveryRequestRepository _deliveryRequestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReplenishStockCommandHandler(IStockItemRepository stockItemRepository,
            IDeliveryRequestRepository deliveryRequestRepository, IUnitOfWork unitOfWork)
        {
            _stockItemRepository = stockItemRepository;
            _deliveryRequestRepository = deliveryRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ReplenishStockCommand request, CancellationToken cancellationToken)
        {
            var stocks = await _stockItemRepository.FindBySkusAsync(request.Items
                    .Select(it => new Sku(it.Sku)).ToArray(),
                cancellationToken);

            await _unitOfWork.StartTransaction(cancellationToken);
            foreach (var stock in stocks)
            {
                var dataToIncrease = request.Items.FirstOrDefault(it =>
                    it.Sku.Equals(stock.Sku.Value)) ?? new StockItemQuantityDto() { Quantity = 0 };

                stock.IncreaseQuantity(dataToIncrease.Quantity);
                await _stockItemRepository.UpdateAsync(stock, cancellationToken);
            }

            var deliveryRequest = await _deliveryRequestRepository
                .FindByRequestNumberAsync(new RequestNumber(request.SupplyId), cancellationToken);
            deliveryRequest.ChangeStatus(RequestStatus.Done);
            await _deliveryRequestRepository.UpdateAsync(deliveryRequest, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}