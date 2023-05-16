using MediatR;
using StockAPI.Application.Models;
using StockAPI.Application.Queries.StockItemAggregate;
using StockAPI.Application.Queries.StockItemAggregate.Responses;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class GetByItemTypeQueryHandler : IRequestHandler<GetByItemTypeQuery, GetByItemTypeQueryResponse>
    {
        private readonly IStockItemRepository _stockItemRepository;

        public GetByItemTypeQueryHandler(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public async Task<GetByItemTypeQueryResponse> Handle(GetByItemTypeQuery request, CancellationToken 
        cancellationToken)
        {
            var items = await _stockItemRepository.FindByItemTypeAsync(request.Id, cancellationToken);
            return new GetByItemTypeQueryResponse
            {
                Items = items.Select(x => new StockItemDto
                {
                    Sku = x.Sku.Value,
                    Name = x.ItemType.Type.Name,
                    ClothingSizeId = x.ClothingSize?.Id,
                    ItemTypeId = x.ItemType.Id,
                    Quantity = x.Quantity.Value,
                    MinimalQuantity = x.MinimalQuantity.Value ?? 0
                }).ToList()
            };
        }
    }
}