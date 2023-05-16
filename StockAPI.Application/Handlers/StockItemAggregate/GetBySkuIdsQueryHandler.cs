using MediatR;
using StockAPI.Application.Models;
using StockAPI.Application.Queries.StockItemAggregate;
using StockAPI.Application.Queries.StockItemAggregate.Responses;
using StockAPI.Domain.AggregationModels.ValueObjects;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class GetBySkuIdsQueryHandler : IRequestHandler<GetBySkuIdsQuery, GetBySkuIdsQueryResponse>
    {
        private readonly IStockItemRepository _stockItemRepository;
        
        public GetBySkuIdsQueryHandler(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }
        
        public async Task<GetBySkuIdsQueryResponse> Handle(GetBySkuIdsQuery request, CancellationToken cancellationToken)
        {
            var dto = request.SkuIds.Select(it => new Sku(it)).ToList();
            var stockItems = await _stockItemRepository.FindBySkusAsync(dto, cancellationToken);

            return new GetBySkuIdsQueryResponse()
            {
                Items = stockItems.Select(it => new StockItemDto()
                {
                    Name = it.Name.Value,
                    Quantity = it.Quantity.Value,
                    Sku = it.Sku.Value,
                    MinimalQuantity = it.MinimalQuantity.Value,
                    ClothingSizeId = it.ClothingSize.Id,
                    ItemTypeId = it.ItemType.Id

                }).ToList()
            };
        }
    }
}