using MediatR;
using StockAPI.Application.Models;

namespace StockAPI.Application.Commands.GiveOutStockItem;

public class GiveOutStockItemCommand : IRequest<GiveOutStockItemResult>
{
    public IReadOnlyList<StockItemQuantityDto> Items { get; init; }
}

public enum GiveOutStockItemResult
{
    Successful =0,
    OutOfStock = 1,
}