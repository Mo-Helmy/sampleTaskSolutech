using Task.Core.Base;

namespace Task.Application.StoreServices.Dto;

public class GetAllStoresQueryDto : PaginationAndSortingDto
{
    public string? Search {  get; set; }
    public bool? IsMain { get; set; }
    public bool? IsInvoiceDirect { get; set; }
    public override string SortField { get; set; } = "Id";

    //public override string SortField { get; set; } = "Id";
}
