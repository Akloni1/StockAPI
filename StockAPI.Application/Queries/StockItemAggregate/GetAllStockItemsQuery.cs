using MediatR;
using StockAPI.Application.Queries.StockItemAggregate.Responses;

namespace StockAPI.Application.Queries.StockItemAggregate
{
    public class GetAllStockItemsQuery : IRequest<GetAllStockItemsQueryResponse>
    {
    }
}