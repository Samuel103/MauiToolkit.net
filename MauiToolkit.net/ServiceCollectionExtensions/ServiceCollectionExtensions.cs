using MauiToolkit.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiToolkit.ServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMauiToolkit(this IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        return services;
    }
}