namespace MudBlazor.ThemeManager;

public class ThemeManagerTheme
{
    public MudTheme Theme { get; set; } = new();

    public bool RTL { get; set; }

    public string FontFamily { get; set; } = "Roboto";

    public int DefaultBorderRadius { get; set; } = 4;

    public int DefaultElevation { get; set; } = 1;

    public int AppBarElevation { get; set; } = 25;

    public int DrawerElevation { get; set; } = 2;

    public DrawerClipMode DrawerClipMode { get; set; } = DrawerClipMode.Never;
}