using Microsoft.AspNetCore.Mvc;
using Task.Application.StoreServices;
using Task.Application.StoreServices.Dto;
using Task.Core.Base;

namespace Task.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController(IStoreService storeService) : ControllerBase
    {
        [HttpGet(nameof(GetAllStores))]
        [ProducesResponseType(typeof(PagedList<StoreResponseDto>), 200)]
        public async Task<IActionResult> GetAllStores([FromQuery] GetAllStoresQueryDto dto, CancellationToken cancellationToken)
        {
            var result = await storeService.GetAllStores(dto, cancellationToken);
            return Ok(result);
        }
        
        [HttpPost(nameof(AddStore))]
        [ProducesResponseType(typeof(StoreDetailsResponseDto), 200)]
        public async Task<IActionResult> AddStore(AddStoreCommandDto dto, CancellationToken cancellationToken)
        {
            var result = await storeService.AddStore(dto, cancellationToken);
            return Ok(result);
        }

        [HttpPost(nameof(EditStore))]
        [ProducesResponseType(typeof(StoreDetailsResponseDto), 200)]
        public async Task<IActionResult> EditStore(EditStoreCommandDto dto, CancellationToken cancellationToken)
        {
            var result = await storeService.EditStore(dto, cancellationToken);
            return Ok(result);
        }

        [HttpPost(nameof(DeleteStore) + "/{id:int}")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> DeleteStore(int id, CancellationToken cancellationToken)
        {
            var result = await storeService.DeleteStore(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost(nameof(SplitStoreSpaces))]
        [ProducesResponseType(typeof(StoreDetailsResponseDto), 200)]
        public async Task<IActionResult> SplitStoreSpaces(SplitStoreSpaceCommandDto dto, CancellationToken cancellationToken)
        {
            var result = await storeService.SplitStoreSpaces(dto, cancellationToken);
            return Ok(result);
        }

        [HttpPost(nameof(DeleteStoreSpace) + "/{storeId:int}/{storeSpaceId:int}")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> DeleteStoreSpace(int storeId, int storeSpaceId, CancellationToken cancellationToken)
        {
            var result = await storeService.DeleteStoreSpaces(storeId, storeSpaceId, cancellationToken);
            return Ok(result);
        }


        [HttpPost(nameof(MergeStoreSpace))]
        [ProducesResponseType(typeof(StoreDetailsResponseDto), 200)]
        public async Task<IActionResult> MergeStoreSpace(MergeStoreSpaceCommandDto dto, CancellationToken cancellationToken)
        {
            var result = await storeService.MergeStoreSpace(dto, cancellationToken);
            return Ok(result);
        }

        [HttpGet(nameof(GetAllProducts))]
        [ProducesResponseType(typeof(PagedList<ProductResponseDto>), 200)]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryDto dto, CancellationToken cancellationToken)
        {
            var result = await storeService.GetAllProducts(dto, cancellationToken);
            return Ok(result);
        }


        [HttpPost(nameof(MoveProduct))]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> MoveProduct(MoveProductCommandDto dto, CancellationToken cancellationToken)
        {
            var result = await storeService.MoveProduct(dto, cancellationToken);
            return Ok(result);
        }
    }
}
