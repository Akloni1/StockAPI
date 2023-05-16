using MediatR;
using StockAPI.Application.Models;
using StockAPI.Application.Queries.StockItemAggregate;
using StockAPI.Application.Queries.StockItemAggregate.Responses;
using StockAPI.Domain.AggregationModels.ValueObjects;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class GetAvailableQuantityQueryHandler : IRequestHandler<GetStockItemsAvailableQuantityQuery, GetStockItemsAvailableQuantityQueryResponse>
    {
        private readonly IStockItemRepository _stockItemRepository;

        public GetAvailableQuantityQueryHandler(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public async Task<GetStockItemsAvailableQuantityQueryResponse> Handle(GetStockItemsAvailableQuantityQuery request, CancellationToken cancellationToken)
        {
            var result = await _stockItemRepository.FindBySkusAsync(request.Skus.Select(x => 
                new Sku(x)).ToList(), cancellationToken);
            return new GetStockItemsAvailableQuantityQueryResponse
            {
                Items = result.Select(x => new StockItemQuantityDto
                {
                    Sku = x.Sku.Value,
                    Quantity = x.Quantity.Value
                }).ToList()
            };
        }
    }
}