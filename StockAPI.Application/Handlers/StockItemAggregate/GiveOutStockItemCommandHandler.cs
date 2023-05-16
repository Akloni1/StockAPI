using MediatR;
using StockAPI.Application.Commands.GiveOutStockItem;
using StockAPI.Domain.AggregationModels.ValueObjects;
using StockAPI.Domain.Exceptions.StockItemAggregate;
using StockAPI.Persistence.Contracts;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class GiveOutStockItemCommandHandler : IRequestHandler<GiveOutStockItemCommand, GiveOutStockItemResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockItemRepository _stockItemRepository;

        public GiveOutStockItemCommandHandler(IStockItemRepository stockItemRepository, IUnitOfWork unitOfWork)
        {
            _stockItemRepository = stockItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GiveOutStockItemResult> Handle(GiveOutStockItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await HandleCore(request, cancellationToken);
            }
            catch (NotEnoughItemsException)
            {
                return GiveOutStockItemResult.OutOfStock;
            }

            return GiveOutStockItemResult.Successful;
        }

        private async Task HandleCore(GiveOutStockItemCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);
            var stockItems = await _stockItemRepository.FindBySkusAsync(
                request.Items.Select(it => new Sku(it.Sku)).ToList(),
                cancellationToken);

            foreach (var stockItem in stockItems)
            {
                stockItem.GiveOutItems(request.Items.FirstOrDefault(it => it.Sku.Equals(stockItem.Sku.Value))?.Quantity ?? 0);
                await _stockItemRepository.UpdateAsync(stockItem, cancellationToken);
            }
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}