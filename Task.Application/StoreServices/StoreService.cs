using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Task.Application.Specifications;
using Task.Application.StoreServices.Dto;
using Task.Core.Base;
using Task.Core.Exceptions;
using Task.Core.Extensions;
using Task.Core.Interfaces.Specification;
using Task.Domain.Entities;
using Task.Infrastructure.Data;

namespace Task.Application.StoreServices;

public class StoreService(AppDbContext appDbContext, IMapper mapper) : IStoreService
{
    public async Task<PagedList<StoreDetailsResponseDto>> GetAllStores(GetAllStoresQueryDto dto, CancellationToken cancellationToken)
    {
        var baseQuery = appDbContext.Stores.AsNoTracking();

        return await SpecificationEvaluator<Store>
            .GetQuery(baseQuery, new StoreSpecification(dto))
            .ProjectTo<StoreDetailsResponseDto>(mapper.ConfigurationProvider)
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
}
