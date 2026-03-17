using Microsoft.Maui.Controls;
using MauiToolkit.ViewModel;

namespace MauiToolkit.Extensions;
public class ExtendedContentPage<T> : ContentPage where T : IExtendedViewModel
{
     T _viewModel;
    
    public T ViewModel => _viewModel;
    
    protected ExtendedContentPage(T viewModel)
    {
        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnViewAppearingAsync();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await _viewModel.OnViewDisappearingAsync();
    }
}