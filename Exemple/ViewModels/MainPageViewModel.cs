using System.Windows.Input;
using MauiToolkit.Services;
using MauiToolkit.ViewModel;

namespace Exemple.ViewModels;

public class MainPageViewModel : ExtendedViewModel
{
    public MainPageViewModel(INavigationService navigationService) : base(navigationService) { }

    public override Task OnViewAppearingAsync()
    {
        Console.WriteLine($"{nameof(MainPageViewModel)} OnViewAppearingAsync");
        return base.OnViewAppearingAsync();
    }

    public override Task OnViewDisappearingAsync()
    {
        Console.WriteLine($"{nameof(MainPageViewModel)} OnViewDisappearingAsync");
        return base.OnViewDisappearingAsync();
    }

    public ICommand NavigateToCustomControls
    {
        get
        {
            return new Command(async () =>
            {
                await NavigationService.NavigateTo<CustomControlViewModel>();
            });
        }
    }

    public ICommand NavigateToProfile
    {
        get
        {
            return new Command(async () =>
            {
                await NavigationService.NavigateTo<ProfileViewModel>();
            });
        }
    }
}