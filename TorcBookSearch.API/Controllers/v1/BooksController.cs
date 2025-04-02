using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using TorcBookSearch.Contracts.UnitsOfWork;
using TorcBookSearch.Models.Queries;
using TorcBookSearch.Models.Requests;

namespace TorcBookSearch.API.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class BooksController(ILogger<BooksController> logger, ISearchBooksUnitOfWork searchBookUow) : ControllerBase
{
    private readonly ILogger<BooksController> _logger = logger;
    private readonly ISearchBooksUnitOfWork _searchBookUow = searchBookUow;

    [HttpGet(Name = "SearchBooks")]
    public async Task<IActionResult> GetAsync([FromQuery] PaginatedSearchRequest<BookQuery> request)
    {   
        try
        {
            _logger.LogInformation("Query request received: {0}", JsonSerializer.Serialize(request));

            var (books, count) = await _searchBookUow.SearchBooksAsync(request);

            return Ok(new { books, count });
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error on trying to search books");

            return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "An error have occured while trying to search books. Please, try later or contact tech support!");
        }
    }
}
