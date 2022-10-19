using Cart.API.Requests;
using Cart.Application.Features.Commands.AddProduct;
using Cart.Application.Features.Commands.CreateCart;
using Cart.Application.Features.Commands.RemoveAllProducts;
using Cart.Application.Features.Commands.RemoveProduct;
using Cart.Application.Features.Queries.GetCart;
using Cart.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userName}")]
    public async Task<ActionResult<CartEntity>> GetCart([FromRoute] string userName)
    {
        try
        {
            GetCartQuery query = new(userName);
            CartEntity entity = await _mediator.Send(query);

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPost("{userName}")]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartCommand command)
    {
        try
        {
            await _mediator.Send(command);

            return StatusCode(201, "Cart created");
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest req)
    {
        try
        {
            AddProductCommand command = new(req.Username, req.ProductId, req.Quantity);
            await _mediator.Send(command);

            return Ok("Product added");
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpDelete("RemoveProduct")]
    public async Task<ActionResult<CartEntity>> RemoveProduct([FromBody] RemoveProductCommand req)
    {
        try
        {
            CartEntity entity = await _mediator.Send(req);

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpDelete("RemoveAll")]
    public async Task<ActionResult<CartEntity>> RemoveAll([FromBody] RemoveAllProductsCommand command)
    {
        try
        {
            CartEntity entity = await _mediator.Send(command);

            if (entity is null)
                return NotFound();

            return Ok(entity);
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}
