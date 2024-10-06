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
        [ProducesResponseType(typeof(PagedList<StoreDetailsResponseDto>), 200)]
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
    }
}
