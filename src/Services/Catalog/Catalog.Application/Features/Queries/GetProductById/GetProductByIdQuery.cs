using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; private set; }

	public GetProductByIdQuery(int id)
	{
		Id = id;
	}
};
