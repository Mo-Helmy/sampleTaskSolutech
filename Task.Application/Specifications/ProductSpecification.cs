using Task.Application.StoreServices.Dto;
using Task.Core.Interfaces.Specification;
using Task.Domain.Entities;

namespace Task.Application.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(GetAllProductsQueryDto dto)
    {
        if (dto.StoreId != null) CriteriaList.Add(x => x.Space.StoreId == dto.StoreId);
        if (dto.StoreSpaceId != null) CriteriaList.Add(x => x.StoreSpaceId == dto.StoreSpaceId);
    }
}
