using TorcBookSearch.Contracts.Repositories;
using TorcBookSearch.Data;
using TorcBookSearch.Models;

namespace TorcBookSearch.Repositories;

internal sealed class BookRepository(TorcBookSearchDbContext context) : RepositoryBase<Book>(context), IBookRepository
{
}
