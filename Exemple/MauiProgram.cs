using MauiToolkit.ServiceCollectionExtensions;
using Microsoft.Extensions.Logging;
using Exemple.ViewModels;
using Exemple.Pages;

namespace Exemple;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<CustomControlViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<CustomControlPage>();
        builder.Services.AddTransient<ProfilePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}