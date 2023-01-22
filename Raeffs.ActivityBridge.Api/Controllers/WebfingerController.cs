using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Raeffs.ActivityBridge.Models;
using Raeffs.ActivityBridge.Webfinger.Models;
using Raeffs.ActivityBridge.Webfinger.Queries;

namespace Raeffs.ActivityBridge.Controllers;

[ApiController]
[Route(".well-known/webfinger")]
public class WebfingerController : ControllerBase
{
    private readonly ISender sender;

    public WebfingerController(ISender sender)
    {
        this.sender = sender;
    }

    public async Task<Results<Ok<WebfingerResource>, NotFound, BadRequest<string>>> Get([FromQuery] WebfingerResourceIdentifier resource, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetWebfingerResourceQuery(resource), cancellationToken);
        return result.Unwrap();
    }
}
