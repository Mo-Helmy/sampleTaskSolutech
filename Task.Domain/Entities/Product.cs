namespace Task.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }


    public int? StoreSpaceId { get; set; }
    public StoreSpace Space { get; set; }
}
