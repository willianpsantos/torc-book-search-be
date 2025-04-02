using TorcBookSearch.Models;
using TorcBookSearch.Models.Queries;
using TorcBookSearch.Models.Requests;

namespace TorcBookSearch.Contracts.UnitsOfWork;

public interface ISearchBooksUnitOfWork
{
    ValueTask<(IEnumerable<Book> books, int count)> SearchBooksAsync(PaginatedSearchRequest<BookQuery> request);
}
