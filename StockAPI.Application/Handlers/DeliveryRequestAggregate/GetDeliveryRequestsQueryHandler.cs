using MediatR;
using StockAPI.Application.Models;
using StockAPI.Application.Queries.DeliveryRequestAggregate;
using StockAPI.Application.Queries.DeliveryRequestAggregate.Responses;
using StockAPI.Domain.AggregationModels.DeliveryRequestAggregate;
using StockAPI.Enums;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Application.Handlers.DeliveryRequestAggregate;

public class GetDeliveryRequestsQueryHandler : IRequestHandler<GetDeliveryRequestsQuery, DeliveryRequestsQueryResponse>
{
    private readonly IDeliveryRequestRepository _deliveryRequestRepository;

    public GetDeliveryRequestsQueryHandler(IDeliveryRequestRepository deliveryRequestRepository)
    {
        _deliveryRequestRepository = deliveryRequestRepository;
    }

    public async Task<DeliveryRequestsQueryResponse> Handle(GetDeliveryRequestsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<DeliveryRequest> fromDb = null;
        if (request.Status == DeliveryRequestStatus.All)
        {
            fromDb = await _deliveryRequestRepository.GetAllRequestsAsync(cancellationToken);
        }
        else
        {
            fromDb = await _deliveryRequestRepository
                .GetRequestsByStatusAsync(new RequestStatus((int)request.Status, ""), cancellationToken);    
        }

        if (fromDb is null)
            return new DeliveryRequestsQueryResponse();

        return new DeliveryRequestsQueryResponse()
        {
            Items = fromDb.Select(it => new DeliveryRequestItem()
            {
                Id = it.Id,
                RequestStatus = (DeliveryRequestStatus)it.RequestStatus.Id,
                SkusCollection = it.SkuCollection.Select(it => it.Value).ToArray(),
                DeliveryRequestId = it.RequestNumber.Value
            }).ToArray()
        };
    }
}