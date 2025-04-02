using System.Text.Json.Serialization;

namespace TorcBookSearch.Models.Requests;

public class PaginatedSearchRequest<TQuery> where TQuery : class
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("take")]
    public int Take { get; set; }

    [JsonPropertyName("query")]
    public TQuery? Query { get; set; }
}
