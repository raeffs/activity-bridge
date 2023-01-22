using MediatR;
using Raeffs.ActivityBridge.Models;
using Raeffs.ActivityBridge.Webfinger.Models;

namespace Raeffs.ActivityBridge.Webfinger.Queries;

public record GetWebfingerResourceQuery(WebfingerResourceIdentifier Resource)
    : IRequest<QueryResult<WebfingerResource>>;
