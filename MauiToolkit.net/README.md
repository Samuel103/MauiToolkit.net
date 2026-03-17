# MauiToolkit.net

A lightweight .NET MAUI toolkit that provides:

- Fluent UI icon controls (`FluentIcon`, `FluentIconButton`)
- A XAML markup extension for font icons (`FluentIconSourceExtension`)
- A simple navigation service (`INavigationService` / `NavigationService`)
- Base ViewModel lifecycle contracts and implementations
- A base page class wired to ViewModel lifecycle (`ExtendedContentPage<T>`)

## What is included

### 1) Fluent icon system

Namespace:

- `MauiToolkit.Controls`
- `MauiToolkit.Fluent`

Types:

- `FluentIcons` enum: large set of Fluent glyph names
- `FluentIconGlyphs.GetGlyph(...)`: maps enum values to glyph unicode
- `FluentIcon` (`Label`): displays an icon from `FluentIcons`
- `FluentIconButton` (`Button`): icon button with optional click scale animation
- `FluentIconSourceExtension`: create `FontImageSource` from a `FluentIcons` value

### 2) Dependency injection setup

Namespace:

- `MauiToolkit.ServiceCollectionExtensions`

Methods:

- `builder.UseMauiToolkit()`
  - Registers font alias: `FluentIconsRegular`
  - Calls `services.AddMauiToolkit()`
- `services.AddMauiToolkit()`
  - Registers `INavigationService` as singleton

### 3) Navigation service

Namespace:

- `MauiToolkit.net.Services`

Behavior:

- `NavigateTo<TViewModel>()` resolves a page type by naming convention:
  - `SomeViewModel` => `SomePage`
- Resolves the page from DI container
- Navigates with `Shell.Current.Navigation.PushAsync(page)`

### 4) ViewModel and Page lifecycle base classes

Namespace:

- `MauiToolkit.ViewModel`
- `MauiToolkit.Extensions`

Types:

- `IExtendedViewModel`
  - `OnViewAppearingAsync()`
  - `OnViewDisappearingAsync()`
- `ILoadableViewModel<T>`
  - `LoadAsync(T parameter)`
- `ExtendedViewModel`
- `ExtendedViewModel<T>`
- `ExtendedContentPage<TViewModel>`
  - Sets `BindingContext`
  - Calls ViewModel lifecycle methods from page `OnAppearing` / `OnDisappearing`

---

## Installation (once published)

```bash
dotnet add package MauiToolkit.net
```

Or add from NuGet Package Manager in Visual Studio.

## Quick start

### 1) Register toolkit in `MauiProgram.cs`

```csharp
using MauiToolkit.ServiceCollectionExtensions;

var builder = MauiApp.CreateBuilder();

builder
    .UseMauiApp<App>()
    .UseMauiToolkit();
```

### 2) Register your Pages and ViewModels in DI

```csharp
builder.Services.AddTransient<MainPage>();
builder.Services.AddTransient<MainViewModel>();
```

> `NavigationService` expects page name convention `XxxViewModel` -> `XxxPage` and page must be resolvable from DI.

### 3) Use icon controls in XAML

```xml
<ContentPage
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:controls="clr-namespace:MauiToolkit.Controls;assembly=MauiToolkit.net"
    xmlns:fluent="clr-namespace:MauiToolkit.Fluent;assembly=MauiToolkit.net">

    <VerticalStackLayout Spacing="12">
        <controls:FluentIcon
            Icon="Home"
            FontSize="28" />

        <controls:FluentIconButton
            Icon="Add"
            Animate="True"
            FontSize="24" />

        <Image>
            <Image.Source>
                <fluent:FluentIconSource
                    Icon="Settings"
                    Size="22" />
            </Image.Source>
        </Image>
    </VerticalStackLayout>
</ContentPage>
```

### 4) Use base page + viewmodel lifecycle

```csharp
public sealed class MainViewModel : ExtendedViewModel
{
    public MainViewModel(INavigationService navigationService)
        : base(navigationService) { }

    public override Task OnViewAppearingAsync()
    {
        // Load data, refresh state, etc.
        return Task.CompletedTask;
    }
}

public partial class MainPage : ExtendedContentPage<MainViewModel>
{
    public MainPage(MainViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}
```

### 5) Navigate using ViewModel type

```csharp
await NavigationService.NavigateTo<ProfileViewModel>();
```

---

## Notes for NuGet packaging

To include this README on NuGet.org, add package metadata to `MauiToolkit.net.csproj`:

```xml
<PropertyGroup>
  <PackageId>MauiToolkit.net</PackageId>
  <Version>1.0.0</Version>
  <Authors>YourName</Authors>
  <Description>Lightweight .NET MAUI toolkit with Fluent icons, navigation service, and ViewModel/page lifecycle helpers.</Description>
  <PackageReadmeFile>README.md</PackageReadmeFile>
</PropertyGroup>

<ItemGroup>
  <None Include="README.md" Pack="true" PackagePath="\" />
</ItemGroup>
```

Then pack and publish:

```bash
dotnet pack MauiToolkit.net/MauiToolkit.net.csproj -c Release
dotnet nuget push <path-to-nupkg> --api-key <NUGET_API_KEY> --source https://api.nuget.org/v3/index.json
```
