namespace Catalog.API.Requests;

public record CreateProductRequest(string Title, string Description, int Quantity, decimal Price);
