using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Task.Application.Specifications;
using Task.Application.StoreServices.Dto;
using Task.Core.Base;
using Task.Core.Exceptions;
using Task.Core.Extensions;
using Task.Core.Specification;
using Task.Domain.Entities;
using Task.Infrastructure.Data;

namespace Task.Application.StoreServices;

public class StoreService(AppDbContext appDbContext, IMapper mapper) : IStoreService
{
    public async Task<PagedList<StoreResponseDto>> GetAllStores(GetAllStoresQueryDto dto, CancellationToken cancellationToken)
    {
        var baseQuery = appDbContext.Stores.AsNoTracking();

        return await SpecificationEvaluator<Store>
            .GetQuery(baseQuery, new StoreSpecification(dto))
            .ProjectTo<StoreResponseDto>(mapper.ConfigurationProvider)
            .PagedResult(dto.PageNumber, dto.PageSize, dto.SortOrder, dto.SortField, cancellationToken);
    }

    public async Task<StoreDetailsResponseDto> AddStore(AddStoreCommandDto dto, CancellationToken cancellationToken)
    {
        var store = mapper.Map<Store>(dto);

        appDbContext.Stores.Add(store);

        await appDbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<StoreDetailsResponseDto>(store);
    }

    public async Task<StoreDetailsResponseDto> EditStore(EditStoreCommandDto dto, CancellationToken cancellationToken)
    {
        var store = mapper.Map<Store>(dto);

        appDbContext.Stores.Update(store);

        await appDbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<StoreDetailsResponseDto>(store);
    }

    public async Task<int> DeleteStore(int storeId, CancellationToken cancellationToken)
    {
        var currentStore = appDbContext.Stores.FirstOrDefault(x => x.Id == storeId) ?? throw new ValidationException("Id not valid", 400);

        appDbContext.Stores.Remove(currentStore);

        return await appDbContext.SaveChangesAsync(cancellationToken);
    }


    public async Task<StoreDetailsResponseDto> SplitStoreSpaces(SplitStoreSpaceCommandDto dto, CancellationToken cancellationToken)
    {
        var currentStore = await appDbContext.Stores.Include(x => x.Spaces).FirstOrDefaultAsync(x => x.Id == dto.StoreId) ?? throw new NotFoundException("Store Not Found");

        for (int i = 1; i <= dto.SplitCount; i++)
        {
            currentStore.Spaces.Add(new StoreSpace() { Name = $"f{i}", StoreId = dto.StoreId });
        }

        appDbContext.Stores.Update(currentStore);

        await appDbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<StoreDetailsResponseDto>(currentStore);
    }


    public async Task<int> DeleteStoreSpaces(int storeId, int storeSpaceId, CancellationToken cancellationToken)
    {
        var currentStore = await appDbContext.Stores.Include(x => x.Spaces).FirstOrDefaultAsync(x => x.Id == storeId) ?? throw new NotFoundException("Store Not Found");
        if(currentStore.Spaces.Count == 1) throw new ValidationException("Store must have at least one space", 400);
        var currentStoreSpace = currentStore.Spaces.FirstOrDefault(x => x.Id == storeSpaceId) ?? throw new NotFoundException("Store space Not Found");


        appDbContext.Spaces.Remove(currentStoreSpace);

        return await appDbContext.SaveChangesAsync(cancellationToken);
    }


    public async Task<StoreDetailsResponseDto> MergeStoreSpace(MergeStoreSpaceCommandDto dto, CancellationToken cancellationToken)
    {
        var currentStore = await appDbContext.Stores.Include(x => x.Spaces).FirstOrDefaultAsync(x => x.Id == dto.StoreId) ?? throw new NotFoundException("Store Not Found");
        var currentMergeSpace = await appDbContext.Spaces.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == dto.MergeSpaceId) ?? throw new NotFoundException("Store space Not Found");
        var currentMergeWithSpace = await appDbContext.Spaces.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == dto.MergeWithSpaceId) ?? throw new NotFoundException("Store space Not Found");

        foreach (var product in currentMergeSpace.Products.ToList())
        {
            product.StoreSpaceId = dto.MergeWithSpaceId;
            appDbContext.Products.Update(product);
        }

        appDbContext.Spaces.Remove(currentMergeSpace);

        await appDbContext.SaveChangesAsync(cancellationToken);

        return mapper.Map<StoreDetailsResponseDto>(currentStore);
    }


    public async Task<PagedList<ProductResponseDto>> GetAllProducts(GetAllProductsQueryDto dto, CancellationToken cancellationToken)
    {
        var baseQuery = appDbContext.Products.AsNoTracking();

        return await SpecificationEvaluator<Product>
            .GetQuery(baseQuery, new ProductSpecification(dto))
            .ProjectTo<ProductResponseDto>(mapper.ConfigurationProvider)
            .PagedResult(dto.PageNumber, dto.PageSize, dto.SortOrder, dto.SortField, cancellationToken);
    }


    public async Task<int> MoveProduct(MoveProductCommandDto dto, CancellationToken cancellationToken)
    {
        var currentProduct = await appDbContext.Products.FirstOrDefaultAsync(x => x.Id == dto.ProductId) ?? throw new NotFoundException("Product Not Found");

        currentProduct.StoreSpaceId = dto.NewSpaceId;

        appDbContext.Products.Update(currentProduct);

        return await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
