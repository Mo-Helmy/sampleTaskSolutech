namespace Task.Core.Base;

public abstract class PaginationDto
{
    private const int maxPageSize = 100;
    private int pageSize = 10;

    public virtual int PageNumber { get; set; } = 1;
    public virtual int PageSize { get => pageSize; set => pageSize = value > maxPageSize ? maxPageSize : value; }
}
