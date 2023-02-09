using AllPlay.Services.Identity.Infrastructure.DAL;
using Messier.Postgres;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AllPlay.Services.Identity.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddPostgres<IdentityDbContext>(configuration)
            .AddOutbox<IdentityDbContext>(configuration);

        return serviceCollection;
    }
}