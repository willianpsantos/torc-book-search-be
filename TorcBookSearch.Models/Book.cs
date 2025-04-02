namespace TorcBookSearch.Models;

public sealed class Book : Entity
{
    public required string Title { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public int? TotalCopies { get; set; }
    public int? CopiesInUse { get; set; }
    public string? Type { get; set; }
    public string? ISBN { get; set; }
    public string? Category { get; set; }
}
