﻿using MediatR;
using StockAPI.Application.Models;
using StockAPI.Application.Queries.StockItemAggregate;
using StockAPI.Application.Queries.StockItemAggregate.Responses;
using StockAPI.Persistence.Contracts;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class GetAllStockItemsQueryHandler : IRequestHandler<GetAllStockItemsQuery, GetAllStockItemsQueryResponse>
    {
        private readonly IStockItemRepository _stockItemRepository;

        public GetAllStockItemsQueryHandler(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }
        
        public async Task<GetAllStockItemsQueryResponse> Handle(GetAllStockItemsQuery request, CancellationToken 
            cancellationToken)
        {
            var items = await _stockItemRepository.GetAllAsync(cancellationToken);
            return new GetAllStockItemsQueryResponse
            {
                Items = items.Select(x => new StockItemDto
                {
                    Sku = x.Sku.Value,
                    Name = x.Name.Value,
                    ClothingSizeId = x.ClothingSize?.Id,
                    ItemTypeId = x.ItemType.Type.Id,
                    Quantity = x.Quantity.Value,
                    MinimalQuantity = x.MinimalQuantity.Value ?? 0,
                }).ToList()
            };
        }
    }
}