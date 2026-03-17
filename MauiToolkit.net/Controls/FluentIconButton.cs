using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MauiToolkit.Controls;
using MauiToolkit.Fluent;

namespace MauiToolkit.Controls;
public class FluentIconButton : Button
{
    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(
            nameof(Icon),
            typeof(Fluent.FluentIcons),
            typeof(FluentIconButton),
            default(Fluent.FluentIcons),
            propertyChanged: OnIconChanged);

    public FluentIcons Icon
    {
        get => (FluentIcons)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    
    public bool Animate { get; set; } = true;

    public FluentIconButton()
    {
        FontFamily = "FluentIconsRegular";
        FontSize = 24;
        Clicked += async (s, e) =>
        {
            if (Animate)
            {
                await this.ScaleToAsync(1.2, 75, Easing.CubicIn);
                await this.ScaleToAsync(1.0, 75, Easing.CubicOut);
            }
        };
    }

    static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not FluentIconButton control)
        {
            return;
        }

        var icon = newValue switch
        {
            FluentIcons typedIcon => typedIcon,
            int rawValue => (FluentIcons)rawValue,
            string name when Enum.TryParse<FluentIcons>(name, true, out var parsed) => parsed,
            _ => default
        };

        control.Text = FluentIconGlyphs.GetGlyph(icon);
    }
}