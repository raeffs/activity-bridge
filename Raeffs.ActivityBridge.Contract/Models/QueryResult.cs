using System.Diagnostics.CodeAnalysis;

namespace Raeffs.ActivityBridge.Models;

public record QueryResult
{
    public static QueryResult<TModel> From<TModel>(TModel? model) => new() { Model = model };

    public static QueryResult<TModel> Fail<TModel>(string error) => new() { Error = error };
}

public record QueryResult<TModel> : QueryResult
{
    public TModel? Model { get; init; }

    public string? Error { get; init; }

    [MemberNotNullWhen(true, nameof(Model))]
    public bool Found => Model is not null;

    [MemberNotNullWhen(true, nameof(Error))]
    public bool Failed => !string.IsNullOrWhiteSpace(Error);

    public QueryResult<TMappedModel> MapTo<TMappedModel>(Func<TModel, TMappedModel> mapper) => Found
        ? new() { Model = mapper(Model) }
        : new() { Error = Error };
}
