namespace Task.Core.Base;

public abstract class PaginationAndSortingDto : PaginationDto
{
    public virtual SortOrder SortOrder { get; set; } = SortOrder.Desc;
    public abstract string SortField { get; set; }
}

public enum SortOrder
{
    Asc = -1, 
    Desc = 1
}
