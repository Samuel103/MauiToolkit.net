using MauiToolkit.ViewModel;

namespace MauiToolkit.net.Services;

public interface INavigationService
{
    Task NavigateTo<TViewModel>() where TViewModel : class;
}