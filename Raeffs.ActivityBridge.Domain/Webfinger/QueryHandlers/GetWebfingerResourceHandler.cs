using MediatR;
using Microsoft.EntityFrameworkCore;
using Raeffs.ActivityBridge.ModelBuilders;
using Raeffs.ActivityBridge.Models;
using Raeffs.ActivityBridge.Webfinger.Models;
using Raeffs.ActivityBridge.Webfinger.Queries;

namespace Raeffs.ActivityBridge.Webfinger.QueryHandlers;

internal class GetWebfingerResourceHandler : IRequestHandler<GetWebfingerResourceQuery, QueryResult<WebfingerResource>>
{
    private readonly IDatabaseContext databaseContext;
    private readonly IActorBuilder actorBuilder;

    public GetWebfingerResourceHandler(IDatabaseContext databaseContext, IActorBuilder actorBuilder)
    {
        this.databaseContext = databaseContext;
        this.actorBuilder = actorBuilder;
    }

    public async Task<QueryResult<WebfingerResource>> Handle(GetWebfingerResourceQuery request, CancellationToken cancellationToken)
    {
        var user = await databaseContext.Actors.FirstOrDefaultAsync(x => x.Name == request.Resource.User, cancellationToken);
        return QueryResult
            .From(user)
            .MapTo(user => new WebfingerResource
            {
                Subject = request.Resource.ToString(),
                Links = new List<ResourceLink>
                {
                    new()
                    {
                        Rel = "self",
                        Type = "application/activity+json",
                        Href = actorBuilder.GetId(user)
                    }
                }
            });
    }
}
