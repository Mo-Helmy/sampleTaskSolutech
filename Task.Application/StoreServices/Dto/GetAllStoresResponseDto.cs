namespace Task.Application.StoreServices.Dto;

public class StoreDetailsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsMain { get; set; }
    public bool IsInvoiceDirect { get; set; }
    public string Address { get; set; }
}
