namespace StockAPI.Domain.Exceptions.DeliveryRequestAggregate;

public class DeliveryRequestStatusException : Exception
{
    public DeliveryRequestStatusException(string message) : base(message)
    {
            
    }
        
    public DeliveryRequestStatusException(string message, Exception innerException) : base(message, innerException)
    {
            
    }
}