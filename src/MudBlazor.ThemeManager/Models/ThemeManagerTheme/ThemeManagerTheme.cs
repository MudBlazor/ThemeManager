using MudBlazor.ThemeManager.Enums;

namespace MudBlazor.ThemeManager.Models.ThemeManagerTheme;

internal class ThemeManagerTheme
{
    public string PresetThemes { get; set; }
    public Modes Mode { get; set; }
    public ThemeManagerThemePalette Palette { get; set; } = new();
    public int DefaultBorderRadiusAsInt { get; set; }
    public LayoutProperties LayoutProperties { get; set; }
}