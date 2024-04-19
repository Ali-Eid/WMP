using Microsoft.Extensions.DependencyInjection;
using WMBProject.Infrastructure.Bases.RepositoryBase;
using WMBProject.Infrastructure.Repositories.Artists;
using WMBProject.Infrastructure.Repositories.Songs;

namespace WMBProject.Infrastructure;

public static class ModuleInfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IArtistRepository, ArtistRepository>();
        services.AddTransient<ISongRepository, SongRepository>();

        return services;
    }
}

