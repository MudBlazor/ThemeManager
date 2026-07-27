using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace MudBlazor.ThemeManager;

public partial class MudThemeManagerColorItem : ComponentBase
{
    private bool _isOpen;

    [CascadingParameter]
    protected MudThemeManager ThemeManager { get; set; } = null!;

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public MudColor? ThemeColor { get; set; }

    [Parameter]
    public ThemePaletteColor ColorType { get; set; }

    [Parameter]
    public ColorPickerView ColorPickerView { get; set; } = ColorPickerView.Spectrum;

    public void ToggleOpen()
    {
        _isOpen = !_isOpen;
    }

    public Task UpdateColor(MudColor value)
    {
        ThemeColor = value;
        var newPaletteColor = new ThemeUpdatedValue
        {
            ColorStringValue = value.ToString(),
            ThemePaletteColor = ColorType
        };

        return ThemeManager.UpdatePalette(newPaletteColor);
    }
}