using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MudBlazor.ThemeManager;

public partial class MudThemeManagerButton : ComponentBase
{
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }
}