using System.Linq.Expressions;

namespace TorcBookSearch.Models.Queries;

public sealed class BookQuery
{
    public string? Title { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public int TotalCopies { get; set; }
    public int CopiesInUse { get; set; }
    public string? Type { get; set; }
    public string? ISBN { get; set; }
    public string? Category { get; set; }

    public Expression<Func<Book, bool>> ToPredicate()
    {
        return _ => ((Title == null || Title == "") || _.Title.ToLower().Contains(Title.ToLower())) &&
                    ((Firstname == null || Firstname == "") || _.Firstname.ToLower().Contains(Firstname.ToLower())) &&
                    ((Lastname == null || Lastname == "") || _.Lastname.ToLower() == Lastname.ToLower()) &&
                    ((TotalCopies == 0) || _.TotalCopies == TotalCopies) &&
                    ((CopiesInUse == 0) || _.CopiesInUse == CopiesInUse) &&
                    ((Type == null || Type == "") || _.Type.ToLower() == Type.ToLower()) &&
                    ((ISBN == null || ISBN == "") || _.ISBN.ToLower() == ISBN.ToLower()) &&
                    ((Category == null || Category == "") || _.Category.ToLower() == Category.ToLower());
    }
}
