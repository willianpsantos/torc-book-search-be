using TorcBookSearch.Contracts.Repositories;
using TorcBookSearch.Contracts.UnitsOfWork;
using TorcBookSearch.Models;
using TorcBookSearch.Models.Queries;
using TorcBookSearch.Models.Requests;

namespace TorcBookSearch.UnitsOfWork
{
    public sealed class SearchBooksUnitOfWork(IBookRepository repository) : ISearchBooksUnitOfWork
    {
        private readonly IBookRepository _repository = repository;

        public async ValueTask<(IEnumerable<Book> books, int count)> SearchBooksAsync(PaginatedSearchRequest<BookQuery> request)
        {
            Book[] books = await
                (request is null or { Query: null }
                    ? _repository.GetAllAsync(request?.Page ?? 0, request?.Take ?? 0)
                    : _repository.GetAsync(request.Query.ToPredicate(), request.Page, request.Take));

            int count = await
                (request is null or { Query: null }
                    ? _repository.CountAsync()
                    : _repository.CountAsync(request.Query.ToPredicate()));

            return (books, count);
        }
    }
}
