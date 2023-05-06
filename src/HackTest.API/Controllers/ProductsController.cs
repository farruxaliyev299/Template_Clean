using HackTest.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackTest.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _medaitor;

    public ProductsController(IMediator medaitor)
    {
        _medaitor = medaitor;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _medaitor.Send(new GetProductsQuery()));
    } 
}
