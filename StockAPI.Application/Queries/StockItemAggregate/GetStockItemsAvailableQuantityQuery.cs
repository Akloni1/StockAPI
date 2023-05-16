using MediatR;
using StockAPI.Application.Queries.StockItemAggregate.Responses;

namespace StockAPI.Application.Queries.StockItemAggregate
{
    /// <summary>
    /// Полуить доступное количество товарных позиций
    /// </summary>
    public class GetStockItemsAvailableQuantityQuery : IRequest<GetStockItemsAvailableQuantityQueryResponse>
    {
        /// <summary>
        /// Идентификатор товарной позиции
        /// </summary>
        public IReadOnlyList<long> Skus { get; set; }
    }
}