using Task.Domain.Entities;

namespace Task.Application.StoreServices.Dto;

public class StoreSpaceDetailsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? StoreId { get; set; }

    public StoreResponseDto Store { get; set; }

    public IEnumerable<Product> Products { get; set; } = [];
}
