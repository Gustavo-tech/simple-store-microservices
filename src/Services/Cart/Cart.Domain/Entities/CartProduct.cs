namespace Cart.Domain.Entities;

public class CartProduct
{
	private int _productId;
	private int _quantity;

	public int ProductId
	{
		get { return _productId; }
		private set 
		{
			if (value < 1)
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

	public CartProduct(int productId, int quantity)
	{
		ProductId = productId;
		Quantity = quantity;
	}
}
