using MediatR;
using StockAPI.Application.Queries.DeliveryRequestAggregate.Responses;
using StockAPI.Enums;

namespace StockAPI.Application.Queries.DeliveryRequestAggregate
{
    public class GetDeliveryRequestsQuery : IRequest<DeliveryRequestsQueryResponse>
    {
        public DeliveryRequestStatus Status { get; set; }
    }
}