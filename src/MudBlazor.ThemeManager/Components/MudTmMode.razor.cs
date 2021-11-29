using Microsoft.AspNetCore.Components;
using MudBlazor.ThemeManager.Enums;

namespace MudBlazor.ThemeManager.Components;

public partial class MudTmMode
{
    [EditorRequired] [Parameter] public Modes Mode { get; set; }
    [EditorRequired] [Parameter] public EventCallback<Modes> ModeChanged { get; set; }

    private void UpdateMode(Modes mode)
    {
        Mode = mode;
        ModeChanged.InvokeAsync(mode);
    }
}