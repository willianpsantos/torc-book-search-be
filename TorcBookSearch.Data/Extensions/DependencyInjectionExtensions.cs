using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TorcBookSearch.Models;

namespace TorcBookSearch.Data.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddTorcBookSearchDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<TorcBookSearchDbContextFactory>();

        return services.AddDbContext<TorcBookSearchDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString(AppConstants.CONNECTION_STRING_NAME);

            options.UseSqlServer(connectionString);
        });
    }
}
