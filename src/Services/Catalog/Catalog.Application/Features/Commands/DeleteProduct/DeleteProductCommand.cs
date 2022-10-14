using MediatR;

namespace Catalog.Application.Features.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public int Id { get; private set; }

	public DeleteProductCommand(int id)
	{
		Id = id;
	}
}
