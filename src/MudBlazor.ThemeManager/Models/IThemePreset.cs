namespace MudBlazor.ThemeManager;


public interface IThemePreset
{
    string NamePreset { get; }

    MudTheme Theme { get; }
}