namespace Task.Core.Base;

public class PagedList<T>
{
    public PageInfoResult PageInfoResult { get; set; }

    public List<T>? Result { get; set; }
}
