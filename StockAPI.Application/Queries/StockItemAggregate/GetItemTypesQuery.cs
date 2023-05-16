using MediatR;
using StockAPI.Application.Queries.StockItemAggregate.Responses;

namespace StockAPI.Application.Queries.StockItemAggregate
{
    public class GetItemTypesQuery : IRequest<GetItemTypesQueryResponse>
    {
        
    }
}