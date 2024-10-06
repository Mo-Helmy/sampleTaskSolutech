namespace Task.Domain.Entities;

public class StoreSpace
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDefault { get; set; }

    public int? StoreId { get; set; }
    public Store Store { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}

