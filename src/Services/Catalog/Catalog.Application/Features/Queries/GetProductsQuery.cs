using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Features.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
}
