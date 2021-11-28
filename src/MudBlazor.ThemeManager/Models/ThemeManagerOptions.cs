using MudBlazor.ThemeManager.Enums;
using MudBlazor.ThemeManager.Models.Sections;

namespace MudBlazor.ThemeManager.Models;

public class ThemeManagerOptions
{
    internal Dictionary<ColorTitles, ColorSectionOptions> ColorSections { get; set; } = new()
    {
        {ColorTitles.Primary, new ColorSectionOptions {Display = true}},
        {ColorTitles.Secondary, new ColorSectionOptions {Display = false}},
        {ColorTitles.Tertiary, new ColorSectionOptions {Display = false}},
        {ColorTitles.Info, new ColorSectionOptions {Display = false}},
        {ColorTitles.Success, new ColorSectionOptions {Display = false, Variant = ColorSectionVariants.Advanced}},
        {ColorTitles.Warning, new ColorSectionOptions {Display = false, Variant = ColorSectionVariants.Advanced}},
        {ColorTitles.Error, new ColorSectionOptions {Display = false, Variant = ColorSectionVariants.Advanced}},
        {ColorTitles.Dark, new ColorSectionOptions {Display = false, Variant = ColorSectionVariants.Advanced}}
    };

    public string DefaultPresetThemeSelected { get; set; } = PresetThemes.Custom;
    public Modes DefaultMode { get; set; } = Modes.Light;
    public Palette LightPalette { get; set; } = PresetThemes.GetDefaultLightPalette();
    public Palette DarkPalette { get; set; } = PresetThemes.GetDefaultDarkPalette();
    public bool ShowPresetThemeSection { get; set; } = true;
    public bool ShowModeSection { get; set; } = true;
    public bool ShowLayoutSection { get; set; }
    public SectionOptions LayoutSectionOptions { get; set; }
    public bool ShowColorSections { get; set; } = true;
    public SectionOptions ColorSectionOptions { get; set; } = new() {DefaultOpen = true};

    // TODO: Should we add more functions to update single prop of a color section?
    public void UpdateColorSection(ColorTitles title, ColorSectionOptions sectionOptions)
    {
        ColorSections[title] = sectionOptions;
    }
}