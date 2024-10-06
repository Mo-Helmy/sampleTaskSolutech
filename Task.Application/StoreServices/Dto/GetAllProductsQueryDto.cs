using Task.Core.Base;

namespace Task.Application.StoreServices.Dto;

public class GetAllProductsQueryDto : PaginationAndSortingDto
{
    public int? StoreId { get; set; }
    public int? StoreSpaceId { get; set; }

    public override string SortField { get; set; } = "Id";
}
