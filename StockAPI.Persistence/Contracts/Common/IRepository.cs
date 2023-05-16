using StockAPI.Domain.Common;

namespace StockAPI.Persistence.Contracts.Common;

public interface IRepository<TEntity> where TEntity : Entity
{
}