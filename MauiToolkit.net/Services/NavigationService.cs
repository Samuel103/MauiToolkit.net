using MauiToolkit.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace MauiToolkit.net.Services;
public class NavigationService : INavigationService
{
    private readonly IServiceProvider _services;

    public NavigationService(IServiceProvider services)
    {
        _services = services;
    }

    public async Task NavigateTo<TViewModel>() where TViewModel : class
    {
        var pageType = ResolvePageType(typeof(TViewModel));

        var page = _services.GetRequiredService(pageType) as Page;

        await Shell.Current.Navigation.PushAsync(page);
    }

    private Type ResolvePageType(Type viewModelType)
    {
        var pageName = viewModelType.Name.Replace("ViewModel", "Page");

        var pageType = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .FirstOrDefault(x => x.Name == pageName);

        if (pageType == null)
            throw new Exception($"Page not found for {viewModelType.Name}");

        return pageType;
    }
}