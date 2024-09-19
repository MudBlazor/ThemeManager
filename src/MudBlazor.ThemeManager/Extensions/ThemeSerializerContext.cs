using System.Text.Json.Serialization;

namespace MudBlazor.ThemeManager.Extensions;

//[JsonSerializable(typeof(MudTheme))] TODO: Needs this to be done https://github.com/MudBlazor/MudBlazor/pull/9434 rest can be removed after
[JsonSerializable(typeof(Shadow))]
[JsonSerializable(typeof(LayoutProperties))]
[JsonSerializable(typeof(ZIndex))]
[JsonSerializable(typeof(PseudoCss))]
internal sealed partial class ThemeSerializerContext : JsonSerializerContext;