namespace MudBlazor.ThemeManager.TestApp.MudThemePresets;


public class CustomThemePreset02 : IThemePreset
{
    public string NamePreset { get; } = "Test Theme";

    public MudTheme Theme { get; } = new()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = Colors.Teal.Default,
            Secondary = Colors.Green.Accent4,
            AppbarBackground = Colors.BlueGray.Default
        },
        PaletteDark = new PaletteDark() { Primary = Colors.Blue.Lighten1 },
        LayoutProperties = new LayoutProperties() { DrawerWidthLeft = "260px", DrawerWidthRight = "300px" }
    };
}