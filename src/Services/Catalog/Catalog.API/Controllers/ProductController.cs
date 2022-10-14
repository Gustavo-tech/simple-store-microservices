using Catalog.API.Requests;
using Catalog.Application.Features.Commands.CreateProduct;
using Catalog.Application.Features.Commands.UpdateProduct;
using Catalog.Application.Features.Queries;
using Catalog.Domain.Entities;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        try
        {
            GetProductsQuery query = new();
            var products = await _mediator.Send(query);

            return Ok(products);
        }
        catch (Exception)
        {
            return Problem();
        }
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
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest req)
    {
        try
        {
            UpdateProductCommand command = new(req.Id, req.Title, req.Description, req.Quantity, req.Price);
            await _mediator.Send(command);

            return Ok("Product updated successfully");
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}
