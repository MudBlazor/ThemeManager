using System.Collections.Generic;
using MudBlazor.ThemeManager.Enums;
using MudBlazor.ThemeManager.Models.Sections;
using MudBlazor.Utilities;

namespace MudBlazor.ThemeManager.Models;

public static class ThemeManagerPresetConfigurations
{
    public static ThemeManagerConfiguration GetPresetConfigOne(MudTheme? theme = null)
    {
        var themeManagerOptions = new ThemeManagerConfiguration
        {
            ShowLayoutSection = true,
            ShowColorSections = true
        };

        themeManagerOptions.UpdateColorSection(ColorTitles.Primary, new ColorSectionOptions
        {
            Display = true,
            SelectedColor = Colors.Green.Default
        });

        themeManagerOptions.UpdateColorSection(ColorTitles.Secondary, new ColorSectionOptions
        {
            Display = true,
            ColorOptions = new List<MudColor>
            {
                Colors.Pink.Default,
                Colors.Amber.Default,
                Colors.Teal.Lighten1,
                Colors.Lime.Default
            },
            SelectedColor = Colors.Amber.Default
        });

        themeManagerOptions.UpdateColorSection(ColorTitles.Tertiary, new ColorSectionOptions
        {
            Display = true,
            Variant = ColorSectionVariants.Advanced,
            SelectedColor = theme is null ? Colors.BlueGrey.Default : theme.Palette.Tertiary.Value
        });

        return themeManagerOptions;
    }
}