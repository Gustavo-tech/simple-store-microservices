using Cart.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Features.Queries.GetCart;

public class GetCartQuery : IRequest<CartEntity>
{
    public string UserName { get; private set; }

    public GetCartQuery(string userName)
    {
        UserName = userName;
    }
}
