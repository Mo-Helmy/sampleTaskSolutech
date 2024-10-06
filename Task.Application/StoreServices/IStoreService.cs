using Task.Application.StoreServices.Dto;
using Task.Core.Base;

namespace Task.Application.StoreServices;

public interface IStoreService
{
    Task<PagedList<StoreResponseDto>> GetAllStores(GetAllStoresQueryDto dto, CancellationToken cancellationToken);
    Task<StoreDetailsResponseDto> AddStore(AddStoreCommandDto dto, CancellationToken cancellationToken);
    Task<StoreDetailsResponseDto> EditStore(EditStoreCommandDto dto, CancellationToken cancellationToken);
    Task<int> DeleteStore(int storeId, CancellationToken cancellationToken);

    Task<StoreDetailsResponseDto> SplitStoreSpaces(SplitStoreSpaceCommandDto dto, CancellationToken cancellationToken);
    Task<int> DeleteStoreSpaces(int storeId, int storeSpaceId, CancellationToken cancellationToken);
    Task<StoreDetailsResponseDto> MergeStoreSpace(MergeStoreSpaceCommandDto dto, CancellationToken cancellationToken);
    Task<PagedList<ProductResponseDto>> GetAllProducts(GetAllProductsQueryDto dto, CancellationToken cancellationToken);
    Task<int> MoveProduct(MoveProductCommandDto dto, CancellationToken cancellationToken);
}