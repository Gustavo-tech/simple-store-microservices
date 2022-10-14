using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Queries.GetProducts;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
}
