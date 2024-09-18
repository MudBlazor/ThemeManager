using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace MudBlazor.ThemeManager.Extensions;

internal static class Extension
{
    private static readonly JsonSerializerOptions JsonOptions = new();
    private static readonly PaletteSerializerContext PaletteSerializerContext = new();

    [RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed.")]
    public static T? DeepClone<T>(this T source)
    {
        if (source is not null)
        {
            var serializeStr = JsonSerializer.Serialize(source, JsonOptions);
            var copyObj = JsonSerializer.Deserialize<T>(serializeStr, JsonOptions);
            return copyObj;
        }

        return default;
    }

    // TODO: Needs this to be done https://github.com/MudBlazor/MudBlazor/pull/9434
    //private static readonly ThemeSerializerContext ThemeSerializerContext = new();

    //public static MudTheme? DeepClone(this MudTheme source)
    //{
    //    var themeType = typeof(MudTheme);
    //    var serializeStr = JsonSerializer.Serialize(source, themeType, ThemeSerializerContext);
    //    var copyObj = (MudTheme?)JsonSerializer.Deserialize(serializeStr, themeType, ThemeSerializerContext);

    //    return copyObj;
    //}

    public static PaletteDark? DeepClone(this PaletteDark source) => DeepClonePalette(source);

    public static PaletteLight? DeepClone(this PaletteLight source) => DeepClonePalette(source);

    private static T? DeepClonePalette<T>(T source) where T : Palette
    {
        var paletteType = typeof(T);
        var serializeStr = JsonSerializer.Serialize(source, paletteType, PaletteSerializerContext);
        var copyObj = (T?)JsonSerializer.Deserialize(serializeStr, paletteType, PaletteSerializerContext);

        return copyObj;
    }
}