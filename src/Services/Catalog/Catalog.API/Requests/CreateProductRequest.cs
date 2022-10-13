namespace Catalog.API.Requests;

public class CreateProductRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
