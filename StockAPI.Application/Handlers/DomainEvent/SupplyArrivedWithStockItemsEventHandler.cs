using System.Text.Json;
using MediatR;
using StockAPI.Domain.Events;

namespace StockAPI.Application.Handlers.DomainEvent
{
    public class SupplyArrivedWithStockItemsEventHandler : INotificationHandler<SupplyArrivedWithStockItemsDomainEvent>
    {
       
        public SupplyArrivedWithStockItemsEventHandler()
        {
            
        }

        public Task Handle(SupplyArrivedWithStockItemsDomainEvent notification, CancellationToken cancellationToken)
        {
           
            // Обработка информации с шины
            
            return Task.CompletedTask;
        }
    }
}