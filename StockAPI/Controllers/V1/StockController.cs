using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockAPI.Application.Commands.CreateStockItem;
using StockAPI.Application.Queries.StockItemAggregate;
using StockAPI.Application.Queries.StockItemAggregate.Responses;
using StockAPI.HttpModels;

namespace StockAPI.Controllers.V1
{
    [ApiController]
    [Route("v1/api/stocks")]
    [Produces("application/json")]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAllStockItemsQueryResponse> GetAll(CancellationToken token)
        {
            return await _mediator.Send(new GetAllStockItemsQuery(), token);
        }

        [HttpPost("byskus")]
        public async Task<IReadOnlyCollection<StockItemPostViewModel>> GetBySkus([FromBody]long[] skus, CancellationToken token)
        {
            var result = await _mediator.Send(new GetBySkuIdsQuery() { SkuIds = skus }, token);

            return result.Items.Select(it => new StockItemPostViewModel()
            {
                Name = it.Name,
                Quantity = it.Quantity,
                Sku = it.Sku,
                Tags = "",
                ClothingSize = it.ClothingSizeId,
                MinimalQuantity = it.MinimalQuantity,
                StockItemType = it.ItemTypeId
            }).ToArray();
        }

        [HttpPost("quantity")]
        public async Task<StockItemQuantityModel[]> GetAvailableQuantity([FromBody]long[] sku, CancellationToken token)
        {
            var result = await _mediator.Send(new GetStockItemsAvailableQuantityQuery
            {
                Skus = sku
            }, token);

            return result.Items.Select(it => new StockItemQuantityModel
            {
                Sku = it.Sku,
                Quantity = it.Quantity
            }).ToArray();
        }

        /// <summary>
        /// Добавляет stock item.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> Add(StockItemPostViewModel postViewModel, CancellationToken token)
        {
            var createStockItemCommand = new CreateStockItemCommand
            {
                Name = postViewModel.Name,
                Quantity = postViewModel.Quantity,
                Sku = postViewModel.Sku,
                Tags = postViewModel.Tags,
                ClothingSize = postViewModel.ClothingSize,
                MinimalQuantity = postViewModel.MinimalQuantity,
                StockItemType = postViewModel.StockItemType
            };
            var result = await _mediator.Send(createStockItemCommand, token);
            return Ok(result);
        }
    }
}