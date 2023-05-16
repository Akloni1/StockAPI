using MediatR;
using StockAPI.Application.Models;
using StockAPI.Application.Queries.StockItemAggregate;
using StockAPI.Application.Queries.StockItemAggregate.Responses;
using StockAPI.Persistence.Contracts;
using StockAPI.Persistence.Contracts.Common;

namespace StockAPI.Application.Handlers.StockItemAggregate
{
    public class GetItemTypesQueryHandler : IRequestHandler<GetItemTypesQuery, GetItemTypesQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemTypeRepository _itemTypeRepository;

        public GetItemTypesQueryHandler(IItemTypeRepository itemTypeRepository, IUnitOfWork unitOfWork)
        {
            _itemTypeRepository = itemTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetItemTypesQueryResponse> Handle(GetItemTypesQuery request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);
            var itemTypes = await _itemTypeRepository.GetAllTypes(cancellationToken); 
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new GetItemTypesQueryResponse
            {
                Items = itemTypes.Select(
                        x => new ItemTypeDto
                        {
                            Id = x.Id,
                            Name = x.Type.Name
                        })
                    .ToList()
            };
        }
    }
}