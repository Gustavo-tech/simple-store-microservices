using Catalog.API.Requests;
using Catalog.Application.Features.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest req)
    {
        try
        {
            CreateProductCommand command = new(req.Title, req.Description, req.Quantity, req.Price);
            await _mediator.Send(command);

            return Ok("Product created successfully");
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}
