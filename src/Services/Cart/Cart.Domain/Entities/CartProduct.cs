namespace Cart.Domain.Entities;

public class CartProduct
{
	private string? _productId;
	private int _quantity;

	public string? ProductId
	{
		get { return _productId; }
		private set 
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new Exception("Invalid product id");

			_productId = value;
		}
	}

	public int Quantity
	{
		get { return _quantity; }
		set
		{
			if (value >= 0)
				_quantity = value;
		}
	}

	public CartProduct(string productId, int quantity)
	{
		ProductId = productId;
		Quantity = quantity;
	}
}
