namespace MudBlazor.ThemeManager.Models;

internal static class PresetThemes
{
    public const string Custom = "Custom";
    public const string MuiDark = "Mui Dark";

    public static Palette GetDefaultLightPalette()
    {
        var palette = new Palette();

        return palette;
    }

    public static Palette GetDefaultDarkPalette()
    {
        var palette = new Palette
        {
            Black = "#27272f",
            Background = "rgb(21,27,34)",
            BackgroundGrey = "#27272f",
            Surface = "#212B36",
            DrawerBackground = "rgb(21,27,34)",
            DrawerText = "rgba(255,255,255, 0.50)",
            DrawerIcon = "rgba(255,255,255, 0.50)",
            AppbarBackground = "#27272f",
            AppbarText = "rgba(255,255,255, 0.70)",
            TextPrimary = "rgba(255,255,255, 0.70)",
            TextSecondary = "rgba(255,255,255, 0.50)",
            ActionDefault = "#adadb1",
            ActionDisabled = "rgba(255,255,255, 0.26)",
            ActionDisabledBackground = "rgba(255,255,255, 0.12)",
            Divider = "rgba(255,255,255, 0.12)",
            DividerLight = "rgba(255,255,255, 0.06)",
            TableLines = "rgba(255,255,255, 0.12)",
            LinesDefault = "rgba(255,255,255, 0.12)",
            LinesInputs = "rgba(255,255,255, 0.3)",
            TextDisabled = "rgba(255,255,255, 0.2)"
        };

        return palette;
    }

    public static MudTheme GetMuiDarkTheme()
    {
        var theme = new MudTheme()
        {
            Palette = new Palette()
            {
                Primary = "#007fff",
                Tertiary = "#594AE2",
                Black = "#27272f",
                Background = "#0a1929",
                BackgroundGrey = "#001e3c",
                Surface = "#001e3c",
                DrawerBackground = "#0a1929",
                DrawerText = "rgba(255,255,255, 0.50)",
                DrawerIcon = "rgba(255,255,255, 0.50)",
                AppbarBackground = "rgb(10, 25, 41)",
                AppbarText = "rgba(255,255,255, 0.70)",
                TextPrimary = "rgba(255,255,255, 0.70)",
                TextSecondary = "rgba(255,255,255, 0.50)",
                ActionDefault = "rgb(173, 173, 177)",
                ActionDisabled = "rgba(0, 127, 255, 0.40)",
                ActionDisabledBackground = "rgba(0, 127, 255, 0.26)",
                Divider = "rgba(0, 127, 255, 0.12)",
                DividerLight = "rgba(20, 127, 255, 0.06)",
                TableLines = "rgba(0, 127, 255, 0.12)",
                LinesDefault = "rgba(0, 127, 255, 0.12)",
                LinesInputs = "rgba(0, 127, 255, 0.3)",
                TextDisabled = "rgba(0, 127, 255, 0.2)"
            },
            LayoutProperties = new LayoutProperties()
            {
                DefaultBorderRadius = "12px",
            }
        };

        return theme;
    }
}