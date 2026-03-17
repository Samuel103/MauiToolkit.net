namespace MauiToolkit.ViewModel;

public interface IExtendedViewModel
{
    Task OnViewAppearingAsync();
    
    Task OnViewDisappearingAsync();
}