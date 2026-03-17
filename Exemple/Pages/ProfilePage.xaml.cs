using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Exemple.ViewModels;
using MauiToolkit.Extensions;

namespace Exemple.Pages;

public partial class ProfilePage : ExtendedContentPage<ProfileViewModel>
{
    public ProfilePage(ProfileViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}