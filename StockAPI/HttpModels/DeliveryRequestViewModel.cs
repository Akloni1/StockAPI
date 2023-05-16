﻿using StockAPI.Enums;

namespace StockAPI.HttpModels
{
    public record DeliveryRequestViewModel
    {
        public long Id { get; init; }

        public long DeliveryRequestId { get; init; }

        public DeliveryRequestStatus RequestStatus { get; init; }
        
        public IReadOnlyList<long> SkusCollection { get; init; }
    }
}