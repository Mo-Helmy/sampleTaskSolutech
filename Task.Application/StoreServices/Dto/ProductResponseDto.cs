using Task.Domain.Entities;

namespace Task.Application.StoreServices.Dto;

public class ProductResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
}
