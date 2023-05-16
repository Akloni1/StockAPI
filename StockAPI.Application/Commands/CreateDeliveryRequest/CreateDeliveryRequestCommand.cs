using MediatR;
using StockAPI.Application.Models;

namespace StockAPI.Application.Commands.CreateDeliveryRequest;

public class CreateDeliveryRequestCommand : IRequest<long>, IItemsModel<DeliveryRequestDto>
{
    public IReadOnlyList<DeliveryRequestDto> Items { get; set; }
}