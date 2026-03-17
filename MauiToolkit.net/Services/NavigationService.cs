using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace MauiToolkit.Services;
public class NavigationService : INavigationService
{
    private static readonly ConcurrentDictionary<Type, Type> PageTypeCache = new();
    private readonly IServiceProvider _services;

    public NavigationService(IServiceProvider services)
    {
        _services = services;
    }

    public async Task NavigateTo<TViewModel>() where TViewModel : class
    {
        var shell = Shell.Current ?? throw new InvalidOperationException("Shell.Current is null. Ensure your app uses a Shell-based root page.");
        var pageType = ResolvePageType(typeof(TViewModel));

        var resolvedPage = _services.GetRequiredService(pageType);
        if (resolvedPage is not Page page)
        {
            throw new InvalidOperationException($"Resolved service '{pageType.FullName}' is not a MAUI Page.");
        }

        await shell.Navigation.PushAsync(page);
    }

    private static Type ResolvePageType(Type viewModelType)
    {
        return PageTypeCache.GetOrAdd(viewModelType, static modelType =>
        {
            var viewModelName = modelType.Name;
            var pageName = viewModelName.EndsWith("ViewModel", StringComparison.Ordinal)
                ? viewModelName.Replace("ViewModel", "Page", StringComparison.Ordinal)
                : $"{viewModelName}Page";

            var matches = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(static assembly =>
                {
                    try
                    {
                        return assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException exception)
                    {
                        return exception.Types.OfType<Type>();
                    }
                })
                .Where(static type => typeof(Page).IsAssignableFrom(type) && !type.IsAbstract)
                .Where(type => type.Name == pageName)
                .ToList();

            if (matches.Count == 0)
            {
                throw new InvalidOperationException($"No page found for ViewModel '{modelType.FullName}'. Expected a page named '{pageName}' and registration in DI.");
            }

            if (matches.Count > 1)
            {
                var candidates = string.Join(", ", matches.Select(static type => type.FullName ?? type.Name));
                throw new InvalidOperationException($"Multiple pages named '{pageName}' were found: {candidates}. Rename pages or make names unique.");
            }

            return matches[0];
        });
    }
}