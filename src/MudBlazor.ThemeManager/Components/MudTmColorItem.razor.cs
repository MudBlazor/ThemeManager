using Microsoft.AspNetCore.Components;
using MudBlazor.ThemeManager.Enums;
using MudBlazor.ThemeManager.Models.Sections;
using MudBlazor.Utilities;

namespace MudBlazor.ThemeManager.Components;

public partial class MudTmColorItem
{
    private bool _isOpen;
    private bool _shouldRender;

    [EditorRequired] [Parameter] public KeyValuePair<ColorTitles, ColorSectionOptions> ColorSection { get; set; }

    [EditorRequired]
    [Parameter]
    public EventCallback<KeyValuePair<ColorTitles, ColorSectionOptions>> ColorChanged { get; set; }

    protected override bool ShouldRender()
    {
        return ColorSection.Value.Variant != ColorSectionVariants.Advanced || _shouldRender;
    }

    private void ToggleOpen()
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

    private async Task UpdateSelectedColor(MudColor color)
    {
        ColorSection.Value.SelectedColor = color.Value;
        await ColorChanged.InvokeAsync(ColorSection);
    }
}