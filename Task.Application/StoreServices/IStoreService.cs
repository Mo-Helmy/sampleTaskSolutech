using Task.Application.StoreServices.Dto;
using Task.Core.Base;

namespace Task.Application.StoreServices;

public interface IStoreService
{
    Task<PagedList<StoreDetailsResponseDto>> GetAllStores(GetAllStoresQueryDto dto, CancellationToken cancellationToken);
    Task<StoreDetailsResponseDto> AddStore(AddStoreCommandDto dto, CancellationToken cancellationToken);
    Task<StoreDetailsResponseDto> EditStore(EditStoreCommandDto dto, CancellationToken cancellationToken);
    Task<int> DeleteStore(int storeId, CancellationToken cancellationToken);
}