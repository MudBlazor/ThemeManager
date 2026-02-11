# ![MudBlazor Logo](content/MudBlazor-GitHub-NoBg-Dark.png)

# Theme Manager / Generator for MudBlazor

[![GitHub](https://img.shields.io/github/license/garderoben/mudblazor?color=594ae2&style=flat-square&logo=github)](https://github.com/Garderoben/MudBlazor.ThemeManager/blob/master/LICENSE)
[![Twitter](https://img.shields.io/twitter/follow/MudBlazor?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/MudBlazor)
[![Nuget version](https://img.shields.io/nuget/v/MudBlazor.ThemeManager?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.ThemeManager/)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)

Blazor Theme Manager component for MudBlazor library. Can be used live or during development to fast and easy try out different theme settings.

**This component is currently not suitable for production applications, be ready for performance issues, bugs and missing features. Feel free to help improve it.**

## Workflow
![caption](content/WorkFlow_DarkTheme.webp)

## Prerequisites
- [MudBlazor](https://www.mudblazor.com/getting-started/installation) Installed and configurated.
## Installation
Install Package
```
dotnet add package MudBlazor.ThemeManager
```
Add the following to `_Imports.razor`
```razor
@using MudBlazor.ThemeManager
```
Add the following to your HTML `head` section, it's either `index.html` or `_Layout.cshtml`/`_Host.cshtml`/`App.razor` depending on whether you're running WebAssembly or Server.
```razor
<link href="https://fonts.googleapis.com/css2?family=Ubuntu:wght@300;400;500;700&display=swap" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600;700&display=swap" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />
<link href="_content/MudBlazor.ThemeManager/MudBlazorThemeManager.css" rel="stylesheet" />
```
Add the components in your `MainLayout.razor` and inside `<MudLayout>`
```razor
<MudThemeManagerButton OnClick="@((e) => OpenThemeManager(true))" />
<MudThemeManager Open="_themeManagerOpen" OpenChanged="OpenThemeManager" Theme="_themeManager" ThemeChanged="UpdateTheme" IsDarkMode="@_isDarkMode" />
```
Add the following inside your @code for `MainLayout.razor`
```razor
private ThemeManagerTheme _themeManager = new ThemeManagerTheme();
public bool _themeManagerOpen = false;
private bool _isDarkMode;

void OpenThemeManager(bool value)
{
    _themeManagerOpen = value;
}

void UpdateTheme(ThemeManagerTheme value)
{
    _themeManager = value;
    StateHasChanged();
}

protected override void OnInitialized()
{
    StateHasChanged();
}
```
## Dark Mode Support
If you need dark mode support, make sure to bind the `IsDarkMode` parameter to a variable that controls whether your application is in dark mode. This allows the Theme Manager to adjust and display the appropriate palette (light or dark) when you're customizing themes.

The `_isDarkMode` variable should be synchronized with your `MudThemeProvider`'s `IsDarkMode` to ensure consistent dark mode behavior across your application:
```razor
<MudThemeProvider Theme="_themeManager.Theme" @bind-IsDarkMode="@_isDarkMode" />
```

Connect the ThemeManagerTheme with `MudThemeProvider` to control all the theme colors. You can also connect `MudAppBar` and `MudDrawer` directly.
```html
<MudThemeProvider Theme="_themeManager.Theme" />
<MudAppBar Elevation="_themeManager.AppBarElevation">
<MudDrawer @bind-Open="_drawerOpen" ClipMode="_themeManager.DrawerClipMode" Elevation="_themeManager.DrawerElevation">
```
