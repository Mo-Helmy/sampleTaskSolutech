namespace Task.Domain.Entities;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsMain { get; set; }
    public bool IsInvoiceDirect { get; set; }
    public string Address { get; set; }

    public ICollection<StoreSpace> Spaces { get; set; } = [];
}
