using MauiToolkit.net.Services;
using MauiToolkit.ViewModel;

namespace Exemple.ViewModels;

public class ProfileViewModel : ExtendedViewModel
{
    public ProfileViewModel(INavigationService navigationService) : base(navigationService) { }
}