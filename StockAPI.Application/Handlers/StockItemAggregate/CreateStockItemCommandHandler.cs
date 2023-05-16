using MediatR;
using StockAPI.Application.Commands.CreateStockItem;
using StockAPI.Domain.AggregationModels.StockItemAggregate;
using StockAPI.Domain.AggregationModels.ValueObjects;
using StockAPI.Domain.Common;
using StockAPI.Persistence.Contracts;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class CreateStockItemCommandHandler : IRequestHandler<CreateStockItemCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockItemRepository _stockItemRepository;

        public CreateStockItemCommandHandler(IStockItemRepository stockItemRepository, IUnitOfWork unitOfWork)
        {
            _stockItemRepository = stockItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateStockItemCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);
            var stockInDb = await _stockItemRepository.FindBySkuAsync(new Sku(request.Sku), cancellationToken);
            if (stockInDb is not null)
                throw new Exception($"Stock item with sku {request.Sku} already exist");

            var newStockItem = new StockItem(
                new Sku(request.Sku),
                new Name(request.Name),
                new Item(Enumeration
                    .GetAll<ItemType>()
                    .FirstOrDefault(it => it.Id.Equals(request.StockItemType))),
                Enumeration
                    .GetAll<ClothingSize>()
                    .FirstOrDefault(it => it.Id.Equals(request.ClothingSize)),
                new Quantity(request.Quantity),
                new QuantityValue(request.MinimalQuantity)
                );

            var createResult = await _stockItemRepository.CreateAsync(newStockItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return newStockItem.Id;
        }
    }
}