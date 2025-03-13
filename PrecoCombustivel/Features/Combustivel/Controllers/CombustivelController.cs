using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PrecoCombustivel.Features.Combustivel.Commands;
using PrecoCombustivel.Features.Combustivel.Queries;


namespace PrecoCombustivel.Features.Combustivel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CombustivelController : ControllerBase
{
    private readonly IMediator _mediator;

    public CombustivelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCombustivelCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetCombustivelListQuery());
        return Ok(result.Value);
    }
}

