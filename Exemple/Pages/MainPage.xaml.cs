using MauiToolkit.Extensions;

namespace Exemple.Pages;

public partial class MainPage : ExtendedContentPage<ViewModels.MainPageViewModel>
{
    public MainPage(ViewModels.MainPageViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}