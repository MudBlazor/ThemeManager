using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MudBlazor.ThemeManager
{
    public partial class MudThemeManager
    {
        public bool Clipped { get; set; }
        public bool Dark { get; set; }
        public bool Rtl { get; set; }

        public string Font { get; set; } = "Montserrat";
        public int BorderRadius { get; set; } = 3;

        [Parameter] public bool Open { get; set; }
        [Parameter] public EventCallback<bool> OpenChanged { get; set; }
        [Parameter] public MudTheme Theme { get; set; } = new MudTheme();
        [Parameter] public EventCallback<MudTheme> ThemeChanged { get; set; }
        async Task UpdateOpenValue()
        {
            Open = false;
            await OpenChanged.InvokeAsync(false);
        }

        async Task UpdateTheme()
        {
            await ThemeChanged.InvokeAsync(_currentTheme);
        }

        void UpdatePalette(ThemeUpdatedValue value)
        {
            var newPalette = _customTheme.Palette;

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
                case ThemePaletteColor.BackgroundGrey:
                    newPalette.BackgroundGrey = value.ColorStringValue;
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
            _customTheme.Palette = newPalette;
            _currentTheme = _customTheme;

            UpdateTheme();
        }
        protected override void OnInitialized()
        {
            _currentTheme = Theme;
            _customTheme = Theme;
        }

        private void DarkMode()
        {
            //if (_currentTheme == MudBlazorAdminDashboard.DefaultTheme)
            //{
            //    _currentTheme = MudBlazorAdminDashboard.DarkTheme;
            //}
            //else
            //{
            //    _currentTheme = MudBlazorAdminDashboard.DefaultTheme;
            //}
        }

        public static MudTheme _currentTheme { get; set; }
        public static MudTheme _customTheme { get; set; }
        public static MudTheme _defaultTheme { get; set; } = new MudTheme();
    }
}
