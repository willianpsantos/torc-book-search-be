using Microsoft.Extensions.DependencyInjection;
using TorcBookSearch.Contracts.UnitsOfWork;

namespace TorcBookSearch.UnitsOfWork.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddUnitsOfWork(this IServiceCollection services)
    {
        return services.AddScoped<ISearchBooksUnitOfWork, SearchBooksUnitOfWork>();
    }
}
