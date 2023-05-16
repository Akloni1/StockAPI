using MediatR;
using StockAPI.Application.Queries.StockItemAggregate.Responses;

namespace StockAPI.Application.Queries.StockItemAggregate
{
    public class GetBySkuIdsQuery : IRequest<GetBySkuIdsQueryResponse>
    {
        public IReadOnlyCollection<long> SkuIds { get; set; }
    }
}