using System.Collections.Concurrent;
using StockAPI.Domain.Common;

namespace StockAPI.Persistence.Infrastructure.Implementation
{
    public class ChangeTracker : IChangeTracker
    {
        public IDictionary<int, Entity> TrackedEntities => _usedEntitiesBackingField;

        // Можно заменить на любую другую имплементацию. Не только через ConcurrentBag
        private readonly ConcurrentDictionary<int, Entity> _usedEntitiesBackingField;

        public ChangeTracker()
        {
            _usedEntitiesBackingField = new ConcurrentDictionary<int, Entity>();
        }
        
        public void Track(Entity entity)
        {
            _usedEntitiesBackingField.TryAdd(entity.GetHashCode(), entity);
        }
    }
}