using MediatR;
using StockAPI.Application.Queries.StockItemAggregate;
using StockAPI.Application.Queries.StockItemAggregate.Responses;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class GetStockItemsAvailableQuantityQueryHandler : IRequestHandler<GetStockItemsAvailableQuantityQuery, GetStockItemsAvailableQuantityQueryResponse>
    {
        private readonly IStockItemRepository _stockItemRepository;

        public GetStockItemsAvailableQuantityQueryHandler(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public Task<GetStockItemsAvailableQuantityQueryResponse> Handle(GetStockItemsAvailableQuantityQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}