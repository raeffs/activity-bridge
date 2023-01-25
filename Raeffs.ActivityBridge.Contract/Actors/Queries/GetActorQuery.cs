using KristofferStrube.ActivityStreams;
using MediatR;
using Raeffs.ActivityBridge.Models;

namespace Raeffs.ActivityBridge.Actors.Queries;

public record GetActorQuery(string Name) : IRequest<QueryResult<Actor>>;
