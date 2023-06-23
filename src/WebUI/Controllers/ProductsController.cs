using dotnet_clean_architecture.Application.Common.Models;
using dotnet_clean_architecture.Application.Products.Commands.CreateProduct;
using dotnet_clean_architecture.Application.Products.Commands.DeleteProduct;
using dotnet_clean_architecture.Application.Products.Commands.UpdateProduct;
using dotnet_clean_architecture.Application.Products.Queries.GetProductDetail;
using dotnet_clean_architecture.Application.Products.Queries.GetProductsWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_clean_architecture.WebUI.Controllers;

public class ProductsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProductBriefDto>>> GetProductsWithPagination([FromQuery] GetProductsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductBriefDto>> GetProductDetail(int id)
    {
        var request = new GetProductDetailQuery { Id = id };

        return await Mediator.Send(request);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}