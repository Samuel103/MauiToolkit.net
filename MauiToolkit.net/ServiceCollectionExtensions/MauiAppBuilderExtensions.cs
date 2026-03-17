using Microsoft.Maui.Hosting;

namespace MauiToolkit.ServiceCollectionExtensions;

public static class MauiAppBuilderExtensions
{
        public static MauiAppBuilder UseMauiToolkit(this MauiAppBuilder builder)
        {
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("FluentSystemIcons-Regular.ttf", "FluentIconsRegular");
            });

            builder.Services.AddMauiToolkit();
            return builder;
        }
}