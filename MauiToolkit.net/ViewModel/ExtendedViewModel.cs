using MauiToolkit.Services;

namespace MauiToolkit.ViewModel;


public class ExtendedViewModel<T> : ExtendedViewModel, ILoadableViewModel<T>
{
    public ExtendedViewModel(INavigationService navigationService) : base(navigationService) { }

    public virtual Task LoadAsync(T parameter)
    {
        return Task.CompletedTask;
    }
}

public class ExtendedViewModel : IExtendedViewModel
{
    protected readonly INavigationService NavigationService;
    public ExtendedViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }
    public virtual Task OnViewAppearingAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnViewDisappearingAsync()
    {
        return Task.CompletedTask;
    }
}