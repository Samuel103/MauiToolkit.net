using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;

namespace MauiToolkit.Fluent;

public class FluentIconSourceExtension : IMarkupExtension<ImageSource>
{
    public FluentIcons Icon { get; set; }

    public Color? Color { get; set; }

    public double Size { get; set; } = 20;

    public ImageSource ProvideValue(IServiceProvider serviceProvider)
    {
        return new FontImageSource
        {
            FontFamily = "FluentIconsRegular",
            Glyph = FluentIconGlyphs.GetGlyph(Icon),
            Color = Color,
            Size = Size
        };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return ProvideValue(serviceProvider);
    }
}