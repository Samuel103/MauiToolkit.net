using System.Windows.Input;
using Exemple.Pages;
using MauiToolkit.net.Services;
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

    public ICommand NavigateToExemple
    {
        get
        {
            return new Command(async () =>
            {
                await NavigationService.NavigateTo<CustomControlViewModel>();
            });
        }
    }
}