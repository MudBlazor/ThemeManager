using Microsoft.AspNetCore.Components;
using MudBlazor.State;
using MudBlazor.ThemeManager.Extensions;

namespace MudBlazor.ThemeManager;

public partial class MudThemeManager : ComponentBaseWithState
{
    private static readonly PaletteLight DefaultPaletteLight = new();
    private static readonly PaletteDark DefaultPaletteDark = new();
    private readonly ParameterState<bool> _openState;
    private readonly ParameterState<bool> _isDarkModeState;

    private PaletteLight? _currentPaletteLight;
    private PaletteDark? _currentPaletteDark;
    private Palette _currentPalette;
    private MudTheme? _customTheme;

    public MudThemeManager()
    {
        using var registerScope = CreateRegisterScope();
        _openState = registerScope.RegisterParameter<bool>(nameof(Open))
            .WithParameter(() => Open)
            .WithEventCallback(() => OpenChanged);
        _isDarkModeState = registerScope.RegisterParameter<bool>(nameof(IsDarkMode))
            .WithParameter(() => IsDarkMode)
            .WithChangeHandler(OnIsDarkModeChanged);
        _currentPalette = GetPalette();
    }

    public string ThemePresets { get; set; } = "Not Implemented";

    [Parameter]
    public bool Open { get; set; }

    [Parameter]
    public EventCallback<bool> OpenChanged { get; set; }

    [Parameter]
    public ThemeManagerTheme? Theme { get; set; }

    [Parameter]
    public bool IsDarkMode { get; set; }

    [Parameter]
    public ColorPickerView ColorPickerView { get; set; } = ColorPickerView.Spectrum;

    [Parameter]
    public EventCallback<ThemeManagerTheme> ThemeChanged { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _currentPalette = GetPalette();

        if (Theme is null)
        {
            return;
        }

        _customTheme = Theme.Theme.DeepClone();
        _currentPaletteLight = Theme.Theme.PaletteLight.DeepClone();
        _currentPaletteDark = Theme.Theme.PaletteDark.DeepClone();
    }

    public Task UpdatePalette(ThemeUpdatedValue value)
    {
        UpdateCustomTheme();

        if (Theme is null || _customTheme is null)
        {
            return Task.CompletedTask;
        }

        Palette newPalette = _isDarkModeState.Value ? _customTheme.PaletteDark : _customTheme.PaletteLight;

        switch (value.ThemePaletteColor)
        {
            case ThemePaletteColor.Primary:
                newPalette.Primary = value.ColorStringValue;
                break;
            case ThemePaletteColor.Secondary:
                newPalette.Secondary = value.ColorStringValue;
                break;
            case ThemePaletteColor.Tertiary:
                newPalette.Tertiary = value.ColorStringValue;
                break;
            case ThemePaletteColor.Info:
                newPalette.Info = value.ColorStringValue;
                break;
            case ThemePaletteColor.Success:
                newPalette.Success = value.ColorStringValue;
                break;
            case ThemePaletteColor.Warning:
                newPalette.Warning = value.ColorStringValue;
                break;
            case ThemePaletteColor.Error:
                newPalette.Error = value.ColorStringValue;
                break;
            case ThemePaletteColor.Dark:
                newPalette.Dark = value.ColorStringValue;
                break;
            case ThemePaletteColor.Surface:
                newPalette.Surface = value.ColorStringValue;
                break;
            case ThemePaletteColor.Background:
                newPalette.Background = value.ColorStringValue;
                break;
            case ThemePaletteColor.BackgroundGray:
                newPalette.BackgroundGray = value.ColorStringValue;
                break;
            case ThemePaletteColor.DrawerText:
                newPalette.DrawerText = value.ColorStringValue;
                break;
            case ThemePaletteColor.DrawerIcon:
                newPalette.DrawerIcon = value.ColorStringValue;
                break;
            case ThemePaletteColor.DrawerBackground:
                newPalette.DrawerBackground = value.ColorStringValue;
                break;
            case ThemePaletteColor.AppbarText:
                newPalette.AppbarText = value.ColorStringValue;
                break;
            case ThemePaletteColor.AppbarBackground:
                newPalette.AppbarBackground = value.ColorStringValue;
                break;
            case ThemePaletteColor.LinesDefault:
                newPalette.LinesDefault = value.ColorStringValue;
                break;
            case ThemePaletteColor.LinesInputs:
                newPalette.LinesInputs = value.ColorStringValue;
                break;
            case ThemePaletteColor.Divider:
                newPalette.Divider = value.ColorStringValue;
                break;
            case ThemePaletteColor.DividerLight:
                newPalette.DividerLight = value.ColorStringValue;
                break;
            case ThemePaletteColor.TextPrimary:
                newPalette.TextPrimary = value.ColorStringValue;
                break;
            case ThemePaletteColor.TextSecondary:
                newPalette.TextSecondary = value.ColorStringValue;
                break;
            case ThemePaletteColor.TextDisabled:
                newPalette.TextDisabled = value.ColorStringValue;
                break;
            case ThemePaletteColor.ActionDefault:
                newPalette.ActionDefault = value.ColorStringValue;
                break;
            case ThemePaletteColor.ActionDisabled:
                newPalette.ActionDisabled = value.ColorStringValue;
                break;
            case ThemePaletteColor.ActionDisabledBackground:
                newPalette.ActionDisabledBackground = value.ColorStringValue;
                break;

        }

        if (_isDarkModeState.Value)
        {
            _customTheme.PaletteDark = (PaletteDark)newPalette;
        }
        else
        {
            _customTheme.PaletteLight = (PaletteLight)newPalette;
        }
        if (_isDarkModeState.Value)
        {
            _currentPaletteDark = _customTheme.PaletteDark;
            Theme.Theme.PaletteDark = _customTheme.PaletteDark;
        }
        else
        {
            _currentPaletteLight = _customTheme.PaletteLight;
            Theme.Theme.PaletteLight = _customTheme.PaletteLight;
        }

        return UpdateThemeChangedAsync();
    }

    private Task UpdateOpenValueAsync() => _openState.SetValueAsync(false);

    private async Task UpdateThemeChangedAsync()
    {
        await ThemeChanged.InvokeAsync(Theme);
        StateHasChanged();
    }

    private void OnIsDarkModeChanged(ParameterChangedEventArgs<bool> arg)
    {
        if (_customTheme is not null)
        {
            UpdateCustomTheme();
        }
    }

    private Task OnDrawerClipModeAsync(DrawerClipMode value)
    {
        if (Theme is null)
        {
            return Task.CompletedTask;
        }

        Theme.DrawerClipMode = value;

        return UpdateThemeChangedAsync();
    }

    private Task OnDefaultBorderRadiusAsync(int value)
    {
        if (Theme is null)
        {
            return Task.CompletedTask;
        }

        if (_customTheme is null)
        {
            return Task.CompletedTask;
        }

        Theme.DefaultBorderRadius = value;
        var newBorderRadius = _customTheme.LayoutProperties;

        newBorderRadius.DefaultBorderRadius = $"{value}px";

        _customTheme.LayoutProperties = newBorderRadius;
        Theme.Theme = _customTheme;

        return UpdateThemeChangedAsync();
    }

    private Task OnDefaultElevationAsync(int value)
    {
        if (Theme is null || _customTheme is null)
        {
            return Task.CompletedTask;
        }

        Theme.DefaultElevation = value;
        var newDefaultElevation = _customTheme.Shadows;

        string newElevation = newDefaultElevation.Elevation[value];
        newDefaultElevation.Elevation[1] = newElevation;

        _customTheme.Shadows.Elevation[1] = newElevation;
        Theme.Theme = _customTheme;

        return UpdateThemeChangedAsync();
    }

    private Task OnAppBarElevationAsync(int value)
    {
        if (Theme is null)
        {
            return Task.CompletedTask;
        }

        Theme.AppBarElevation = value;

        return UpdateThemeChangedAsync();
    }

    private Task OnDrawerElevationAsync(int value)
    {
        if (Theme is null)
        {
            return Task.CompletedTask;
        }

        Theme.DrawerElevation = value;

        return UpdateThemeChangedAsync();
    }

    private Task OnFontFamilyAsync(string value)
    {
        if (Theme is null || _customTheme is null)
        {
            return Task.CompletedTask;
        }

        Theme.FontFamily = value;
        var newTypography = _customTheme.Typography;

        newTypography.Body1.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.Body2.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.Button.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.Caption.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.Default.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.H1.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.H2.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.H3.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.H4.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.H5.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.H6.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.Overline.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.Subtitle1.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };
        newTypography.Subtitle2.FontFamily = new[] { value, "Helvetica", "Arial", "sans-serif" };

        _customTheme.Typography = newTypography;
        Theme.Theme = _customTheme;

        return UpdateThemeChangedAsync();
    }

    private void UpdateCustomTheme()
    {
        if (_customTheme is null)
        {
            return;
        }

        if (_currentPaletteLight is not null)
        {
            _customTheme.PaletteLight = _currentPaletteLight;
        }

        if (_currentPaletteDark is not null)
        {
            _customTheme.PaletteDark = _currentPaletteDark;
        }

        _currentPalette = GetPalette();
    }

    private Palette GetPalette() => _isDarkModeState.Value
        ? _currentPaletteDark ?? DefaultPaletteDark
        : _currentPaletteLight ?? DefaultPaletteLight;
}