using MauiToolkit.Fluent;
using Microsoft.Maui.Controls;

namespace MauiToolkit.Controls;
public class FluentIcon : Label
{
    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(
            nameof(Icon),
            typeof(FluentIcons),
            typeof(FluentIcon),
            default(FluentIcons),
            propertyChanged: OnIconChanged);

    public FluentIcons Icon
    {
        get => (FluentIcons)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public FluentIcon()
    {
        FontFamily = "FluentIconsRegular";
        FontSize = 24;
    }

    static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not FluentIcon control)
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