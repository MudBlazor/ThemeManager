using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor.ThemeManager.Enums;
using MudBlazor.ThemeManager.Models;
using MudBlazor.ThemeManager.Models.Sections;
using MudBlazor.ThemeManager.Models.ThemeManagerTheme;

namespace MudBlazor.ThemeManager;

public partial class MudThemeManager
{
    private ThemeManagerTheme _themeManagerTheme = new();

    [Inject] private ILocalStorageService LocalStorage { get; set; } = null!;

    /// <summary>
    ///     Sets the opened state of Theme Manager.
    /// </summary>
    [Parameter]
    public bool Open { get; set; }

    /// <summary>
    ///     Event when the opened state of Theme Manager changes.
    /// </summary>
    [Parameter]
    public EventCallback<bool> OpenChanged { get; set; }

    /// <summary>
    ///     Theme Managers drop shadow.
    /// </summary>
    [Parameter]
    public int Elevation { set; get; } = 1;

    /// <summary>
    ///     Side from which the Theme Manager appears.
    /// </summary>
    [Parameter]
    public Anchor Anchor { get; set; } = Anchor.End;

    /// <summary>
    ///     Disable overlay for Theme Manager.
    /// </summary>
    [Parameter]
    public bool DisableOverlay { get; set; } = true;

    /// <summary>
    ///     Sets the theme manager theme.
    /// </summary>
    [Parameter]
    public MudTheme Theme { get; set; } = new();

    /// <summary>
    ///     Event triggered when the theme changes.
    /// </summary>
    [Parameter]
    public EventCallback<MudTheme> ThemeChanged { get; set; }

    /// <summary>
    ///     Options of the Theme Manager.
    /// </summary>
    [Parameter]
    public ThemeManagerOptions Options { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        if (await LocalStorage.ContainKeyAsync("mudThemeManager"))
        {
            _themeManagerTheme = await LocalStorage.GetItemAsync<ThemeManagerTheme>("mudThemeManager");
        }
        else
        {
            _themeManagerTheme.PresetThemes = Options.DefaultPresetThemeSelected;
            _themeManagerTheme.Mode = Options.DefaultMode;
            _themeManagerTheme.Palette.SetThemeManagerThemePalette(Theme.Palette);
            _themeManagerTheme.LayoutProperties = Theme.LayoutProperties;
            
            // TODO: Maybe move that somewhere else?
            
            if(int.TryParse(_themeManagerTheme.LayoutProperties.DefaultBorderRadius.Replace("px", ""),
                out var defaultBorderRadiusAsInt))
                _themeManagerTheme.DefaultBorderRadiusAsInt = defaultBorderRadiusAsInt;
        }

        await UpdateTheme();
    }

    private async Task OnPresetThemeChanged(string presetTheme)
    {
        _themeManagerTheme.PresetThemes = presetTheme switch
        {
            PresetThemes.Custom => PresetThemes.Custom,
            PresetThemes.MuiDark => PresetThemes.MuiDark,
            _ => PresetThemes.Custom
        };

        await UpdateTheme();
    }

    private async Task ToggleMode(Modes mode)
    {
        _themeManagerTheme.Mode = mode;
        await UpdateTheme();
    }

    private async Task UpdateColor(KeyValuePair<ColorTitles, ColorSectionOptions> colorSection)
    {
        switch (colorSection.Key)
        {
            case ColorTitles.Primary:
                _themeManagerTheme.Palette.Primary = colorSection.Value.SelectedColor.Value;
                break;
            case ColorTitles.Secondary:
                _themeManagerTheme.Palette.Secondary = colorSection.Value.SelectedColor.Value;
                break;
            case ColorTitles.Tertiary:
                _themeManagerTheme.Palette.Tertiary = colorSection.Value.SelectedColor.Value;
                break;
            case ColorTitles.Success:
                _themeManagerTheme.Palette.Success = colorSection.Value.SelectedColor.Value;
                break;
            case ColorTitles.Info:
                _themeManagerTheme.Palette.Info = colorSection.Value.SelectedColor.Value;
                break;
            case ColorTitles.Warning:
                _themeManagerTheme.Palette.Warning = colorSection.Value.SelectedColor.Value;
                break;
            case ColorTitles.Error:
                _themeManagerTheme.Palette.Error = colorSection.Value.SelectedColor.Value;
                break;
            case ColorTitles.Dark:
                _themeManagerTheme.Palette.Dark = colorSection.Value.SelectedColor.Value;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        await UpdateTheme();
    }

    private async Task UpdateBorderRadius(int value)
    {
        _themeManagerTheme.DefaultBorderRadiusAsInt = value;
        _themeManagerTheme.LayoutProperties.DefaultBorderRadius = $"{value}px";
        await UpdateTheme();
    }

    private async Task UpdateTheme()
    {
        switch (_themeManagerTheme.PresetThemes)
        {
            case PresetThemes.Custom:
                var palette = _themeManagerTheme.Mode == Modes.Dark
                    ? Options.DarkPalette
                    : Options.LightPalette;
                
                palette.Primary = _themeManagerTheme.Palette.Primary;
                palette.Secondary = _themeManagerTheme.Palette.Secondary;
                palette.Info = _themeManagerTheme.Palette.Info;
                palette.Success = _themeManagerTheme.Palette.Success;
                palette.Warning = _themeManagerTheme.Palette.Warning;
                palette.Error = _themeManagerTheme.Palette.Error;
                palette.Dark = _themeManagerTheme.Palette.Dark;
                
                _themeManagerTheme.Palette.SetThemeManagerThemePalette(palette);
                Theme.Palette = _themeManagerTheme.Palette.GetThemeManagerThemePalette();
                Theme.LayoutProperties = _themeManagerTheme.LayoutProperties;
                
                break;
            case PresetThemes.MuiDark:
                Theme = PresetThemes.GetMuiDarkTheme();
                break;
        }
        
        await ThemeChanged.InvokeAsync(Theme);
        await SaveTheme();
    }

    private async Task SaveTheme()
    {
        await LocalStorage.SetItemAsync("mudThemeManager", _themeManagerTheme);
    }
}