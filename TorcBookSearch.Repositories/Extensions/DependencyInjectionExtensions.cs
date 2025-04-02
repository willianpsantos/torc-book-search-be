using Microsoft.Extensions.DependencyInjection;
using TorcBookSearch.Contracts.Repositories;

namespace TorcBookSearch.Repositories.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IBookRepository, BookRepository>();
    }
}
