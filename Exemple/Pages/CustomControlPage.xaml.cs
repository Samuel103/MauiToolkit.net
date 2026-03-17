using MauiToolkit.Extensions;
using Exemple.ViewModels;

namespace Exemple.Pages
{
    public partial class CustomControlPage : ExtendedContentPage<CustomControlViewModel>
    {
        public CustomControlPage(CustomControlViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}