using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TorcBookSearch.Data;
using TorcBookSearch.Data.Extensions;
using TorcBookSearch.Repositories.Extensions;
using TorcBookSearch.UnitsOfWork.Extensions;

namespace TorcBookSearch.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddTorcBookSearchDbContext(configuration)
            .AddRepositories()
            .AddUnitsOfWork();
    }

    public static void UseDatabaseMigrationsApplying(this IApplicationBuilder builder)
    {
        try
        {
            using var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var factory = scope.ServiceProvider.GetRequiredService<TorcBookSearchDbContextFactory>();
            using var context = factory.CreateDbContext([]);

            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while applying database migrations: {ex.Message}");
        }
    }
}
