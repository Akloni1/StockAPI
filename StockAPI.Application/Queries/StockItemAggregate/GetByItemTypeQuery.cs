using MediatR;
using StockAPI.Application.Queries.StockItemAggregate.Responses;

namespace StockAPI.Application.Queries.StockItemAggregate
{
    public class GetByItemTypeQuery : IRequest<GetByItemTypeQueryResponse>
    {
        /// <summary>
        /// Item type id
        /// </summary>
        public int Id { get; set; }
    }
}