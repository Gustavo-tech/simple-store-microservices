using Catalog.Domain.Common;

namespace Catalog.Domain.Entities;

public class Product : Entity
{
    private int _quantity;
    private string? _title;
    private decimal _price;

    public string? Description { get; private set; }

    public string? Title 
    { 
        get { return _title; } 
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Title is required");
        }
    }

    public int Quantity
    {
        get { return _quantity; }
        private set
        {
            if (value < 0)
                throw new Exception("Quantity must be greater than zero");

            _quantity = value;
        }
    }

    public decimal Price
    {
        get { return _price; }
        private set 
        {
            if (value < 0)
                throw new Exception("Price must be greater than zero");

            _price = value;
        }
    }

    public Product()
    {
    }

    public Product(string title, string description, int quantity)
    {
        Title = title;
        Description = description;
        Quantity = quantity;
    }

    public void ProductSold(int quantity)
    {
        if (quantity <= 0)
            throw new Exception("Quantity must be greater than zero");

        Quantity -= quantity;
    }
}
