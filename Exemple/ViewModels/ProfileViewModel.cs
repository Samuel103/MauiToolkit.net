using MauiToolkit.Services;
using MauiToolkit.ViewModel;

namespace Exemple.ViewModels;

public class ProfileViewModel : ExtendedViewModel<string>
{
    public ProfileViewModel(INavigationService navigationService) : base(navigationService) { }

    public string UserName { get; private set; } = "Maui Toolkit User";

    public override Task OnViewAppearingAsync()
    {
        Console.WriteLine($"{nameof(ProfileViewModel)} OnViewAppearingAsync");
        return LoadAsync("Maui Toolkit User");
    }

    public override Task OnViewDisappearingAsync()
    {
        Console.WriteLine($"{nameof(ProfileViewModel)} OnViewDisappearingAsync");
        return base.OnViewDisappearingAsync();
    }

    public override Task LoadAsync(string parameter)
    {
        UserName = parameter;
        Console.WriteLine($"{nameof(ProfileViewModel)} LoadAsync: {parameter}");
        return Task.CompletedTask;
    }
}