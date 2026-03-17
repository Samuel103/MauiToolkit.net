using Microsoft.Maui.Controls;
using MauiToolkit.ViewModel;

namespace MauiToolkit.Extensions;
public class ExtendedContentPage<T> : ContentPage where T : IExtendedViewModel
{
    private readonly T _viewModel;

    public T ViewModel => _viewModel;

    protected ExtendedContentPage(T viewModel)
    {
        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = ExecuteLifecycleAsync(_viewModel.OnViewAppearingAsync);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _ = ExecuteLifecycleAsync(_viewModel.OnViewDisappearingAsync);
    }

    private static async Task ExecuteLifecycleAsync(Func<Task> lifecycleAction)
    {
        try
        {
            await lifecycleAction();
        }
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception);
        }
    }
}