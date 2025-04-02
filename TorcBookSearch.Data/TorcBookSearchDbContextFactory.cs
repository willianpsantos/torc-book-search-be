using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TorcBookSearch.Models;

namespace TorcBookSearch.Data;

public sealed class TorcBookSearchDbContextFactory : IDesignTimeDbContextFactory<TorcBookSearchDbContext>
{
    public TorcBookSearchDbContext CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        var contextBuilder = new DbContextOptionsBuilder<TorcBookSearchDbContext>();

        var config = configBuilder.AddJsonFile(AppConstants.DEFAULT_APPSETTINGS_FILENAME).Build();
        var connectionString = config.GetConnectionString(AppConstants.CONNECTION_STRING_NAME);

        contextBuilder.UseSqlServer(connectionString);

        return new TorcBookSearchDbContext(contextBuilder.Options);
    }
}
