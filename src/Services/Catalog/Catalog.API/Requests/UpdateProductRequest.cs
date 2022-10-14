namespace Catalog.API.Requests;

public record UpdateProductRequest(int Id, string Title, string Description, int Quantity, decimal Price);
