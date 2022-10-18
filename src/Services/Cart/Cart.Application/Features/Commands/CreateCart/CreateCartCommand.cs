using MediatR;

namespace Cart.Application.Features.Commands.CreateCart;

public class CreateCartCommand : IRequest
{
    public string? UserName { get; set; }

    public CreateCartCommand(string userName)
    {
        UserName = userName;
    }
}
