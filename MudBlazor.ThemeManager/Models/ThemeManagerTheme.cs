
namespace MudBlazor.ThemeManager
{
    public class ThemeManagerTheme
    {
        public MudTheme Theme { get; set; } = new MudTheme();
        public bool RTL { get; set; }
        public int AppBarElevation { get; set; }
        public string FontFamily { get; set; }
        public int DefaultBorderRadius { get; set; }
        public DrawerClipMode DrawerClipMode { get; set; }
    }
}
