using System.Windows.Input;
using MauiToolkit.ViewModel;
using MauiToolkit.Services;

namespace Exemple.ViewModels;

public class CustomControlViewModel : ExtendedViewModel
{
	public CustomControlViewModel(INavigationService navigationService) : base(navigationService){}

	public override Task OnViewAppearingAsync()
	{
		Console.WriteLine($"{nameof(CustomControlViewModel)} OnViewAppearingAsync");
		return base.OnViewAppearingAsync();
	}

	public override Task OnViewDisappearingAsync()
	{
		Console.WriteLine($"{nameof(CustomControlViewModel)} OnViewDisappearingAsync");
		return base.OnViewDisappearingAsync();
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