# ![MudBlazor](content/MudBlazor-GitHub-NoBg.png)
# Theme Manager / Generator for MudBlazor

[![GitHub](https://img.shields.io/github/license/garderoben/mudblazor?color=594ae2&style=flat-square&logo=github)](https://github.com/Garderoben/MudBlazor.ThemeManager/blob/master/LICENSE)
[![Twitter](https://img.shields.io/twitter/follow/MudBlazor?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/MudBlazor)
[![Nuget version](https://img.shields.io/nuget/v/MudBlazor.ThemeManager?color=ff4081&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/MudBlazor.ThemeManager/)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)

Blazor Theme Manager component for MudBlazor library. Can be used live or during development to fast and easy try out different theme settings.

**This component is not suitable for prod applications, be ready for performance issues, bugs and missing features. Feel free to help improve it.**

## Online Demo & Examples
- [MudBlazor Theme Manager](https://thememanager.mudblazor.com/)
- [AdminDashbord Template](https://templates.mudblazor.com/)

## Workflow
![caption](content/WorkFlow_DarkTheme.webp)

## Prerequisites
- [MudBlazor](https://mudblazor.com/) Installed and configurated.
## Installation
Install Package
```
dotnet add package MudBlazor.ThemeManager
```
Add the following to `_Imports.razor`
```razor
@using MudBlazor.ThemeManager
```
Add the following to `index.html` (client-side) or `_Host.cshtml` (server-side) in the `head`
```razor
<link href="https://fonts.googleapis.com/css2?family=Ubuntu:wght@300;400;500;700&display=swap" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600;700&display=swap" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />
<link href="_content/MudBlazor.ThemeManager/MudBlazorThemeManager.css" rel="stylesheet" />
```
Add the components in your `MainLayout.razor` and inside `<MudLayout>`
```razor
<MudThemeManagerButton OnClick="@((e) => OpenThemeManager(true))" />
<MudThemeManager Open="_themeManagerOpen" OpenChanged="OpenThemeManager" Theme="_themeManager" ThemeChanged="UpdateTheme" />
```
Add the following inside your @code for `MainLayout.razor`
```razor
private ThemeManagerTheme _themeManager = new ThemeManagerTheme();

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
Connect the ThemeManagerTheme with `MudThemeProvider` to control all the theme colors. You can also connect `MudAppBar` and `MudDrawer` directly.
```html
<MudThemeProvider Theme="_themeManager.Theme" />
<MudAppBar Elevation="_themeManager.AppBarElevation">
<MudDrawer @bind-Open="_drawerOpen" ClipMode="_themeManager.DrawerClipMode" Elevation="_themeManager.DrawerElevation">
```
