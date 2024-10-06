namespace Task.Application.StoreServices.Dto;

public class StoreSpaceResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDefault { get; set; }
    public int? StoreId { get; set; }
}
