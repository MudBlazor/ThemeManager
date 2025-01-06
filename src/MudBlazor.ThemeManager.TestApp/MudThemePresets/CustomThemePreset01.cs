namespace MudBlazor.ThemeManager.TestApp.MudThemePresets;


public class CustomThemePreset01 : IThemePreset
{
    public string NamePreset { get; } = "Arco Service NET";

    public MudTheme Theme { get; } = new()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = Colors.Brown.Darken3,
            Secondary = Colors.Green.Darken2,
            AppbarBackground = Colors.Red.Default
        },
        PaletteDark = new PaletteDark() { Primary = Colors.Blue.Lighten1 },
        LayoutProperties = new LayoutProperties() { DrawerWidthLeft = "260px", DrawerWidthRight = "300px" }
    };
}