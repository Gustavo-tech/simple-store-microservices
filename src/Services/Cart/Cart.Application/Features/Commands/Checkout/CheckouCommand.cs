using Cart.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Features.Commands.Checkout;
public class CheckouCommand : IRequest<CartEntity>
{
    public string Username { get; private set; }

    public CheckouCommand(string username)
    {
        Username = username;
    }
}
