using KristofferStrube.ActivityStreams;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Raeffs.ActivityBridge.Actors.Queries;
using Raeffs.ActivityBridge.ModelBuilders;
using Raeffs.ActivityBridge.Models;

namespace Raeffs.ActivityBridge.Actors.QueryHandlers;

internal class GetActorHandler : IRequestHandler<GetActorQuery, QueryResult<Actor>>
{
    private readonly IDatabaseContext databaseContext;
    private readonly IActorBuilder actorBuilder;

    public GetActorHandler(IDatabaseContext databaseContext, IActorBuilder actorBuilder)
    {
        this.databaseContext = databaseContext;
        this.actorBuilder = actorBuilder;
    }

    public async Task<QueryResult<Actor>> Handle(GetActorQuery request, CancellationToken cancellationToken)
    {
        var actor = await databaseContext.Actors.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);
        return QueryResult
            .From(actor)
            .MapTo(actorBuilder.GetActor);
    }
}

