using Task.Application.StoreServices.Dto;
using Task.Core.Interfaces.Specification;
using Task.Domain.Entities;

namespace Task.Application.Specifications;

public class StoreSpecification : BaseSpecification<Store>
{
    public StoreSpecification(GetAllStoresQueryDto dto)
    {
        if (dto.Search != null) CriteriaList.Add(x => x.Name.Contains(dto.Search));
        if (dto.IsMain != null) CriteriaList.Add(x => x.IsMain == dto.IsMain);
        if (dto.IsInvoiceDirect != null) CriteriaList.Add(x => x.IsInvoiceDirect == dto.IsInvoiceDirect);
    }
}
