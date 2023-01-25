using KristofferStrube.ActivityStreams;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Raeffs.ActivityBridge.Actors.Queries;
using Raeffs.ActivityBridge.Models;

namespace Raeffs.ActivityBridge.Controllers;

[ApiController]
[Route("api/actors")]
public class ActorController : ControllerBase
{
    private readonly ISender sender;

    public ActorController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet("{name}")]
    public async Task<Results<Ok<Actor>, NotFound, BadRequest<string>>> GetAsync(string name, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetActorQuery(name), cancellationToken);
        return result.Unwrap();
    }
}
