using MediatR;
using StockAPI.Application.Models;

namespace StockAPI.Application.Commands.ReplenishStock;

public class ReplenishStockCommand : IRequest<Unit>
{
    public long SupplyId { get; set; }
    public IReadOnlyCollection<StockItemQuantityDto> Items { get; set; }
}