using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;


namespace MudBlazor.ThemeManager;


public partial class MudThemeManagerColorItem : ComponentBase
{
    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public ColorPickerView ColorPickerView { get; set; } = ColorPickerView.Spectrum;

    [Parameter]
    public MudColor? ThemeColor { get; set; }

    [Parameter]
    public ThemePaletteColor ColorType { get; set; }

    [CascadingParameter]
    protected bool ForceRender { get; set; }

    [CascadingParameter]
    protected MudThemeManager ThemeManager { get; set; } = null!;

    private bool _isOpen;
    private bool _shouldRender;


    protected override bool ShouldRender()
    {
        return ForceRender || _shouldRender;
    }


    public void ToggleOpen()
    {
        if (_isOpen)
        {
            _isOpen = false;
            _shouldRender = false;
        }
        else
        {
            _isOpen = true;
            _shouldRender = true;
        }
    }


    public Task UpdateColor(MudColor value)
    {
        ThemeColor = value;
        var newPaletteColor = new ThemeUpdatedValue { ColorStringValue = value.ToString(), ThemePaletteColor = ColorType };

        return ThemeManager.UpdatePalette(newPaletteColor);
    }
}