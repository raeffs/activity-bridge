using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Raeffs.ActivityBridge.Models;

internal static class QueryResultExtensions
{
    public static Results<Ok<TModel>, NotFound, BadRequest<string>> Unwrap<TModel>(this QueryResult<TModel> result)
        => result.Found
            ? TypedResults.Ok(result.Model)
            : result.Failed
                ? TypedResults.BadRequest(result.Error)
                : TypedResults.NotFound();
}
