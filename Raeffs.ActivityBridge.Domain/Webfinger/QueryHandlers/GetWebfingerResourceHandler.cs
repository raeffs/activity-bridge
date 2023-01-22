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
    private readonly IReferenceBuilder referenceBuilder;

    public GetWebfingerResourceHandler(IDatabaseContext databaseContext, IReferenceBuilder referenceBuilder)
    {
        this.databaseContext = databaseContext;
        this.referenceBuilder = referenceBuilder;
    }

    public async Task<QueryResult<WebfingerResource>> Handle(GetWebfingerResourceQuery request, CancellationToken cancellationToken)
    {
        var user = await databaseContext.Actors.FirstOrDefaultAsync(x => x.Name == request.Resource.User, cancellationToken);
        return QueryResult
            .From(user)
            .Map(user => new WebfingerResource
            {
                Subject = request.Resource.ToString(),
                Links = new List<ResourceLink>
                {
                    new() {
                        Rel = "self",
                        Type = "application/activity+json",
                        Href = referenceBuilder.ForActor(user)
                    }
                }
            });
    }
}
