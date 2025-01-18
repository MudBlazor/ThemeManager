using System.Text.Json;

namespace MudBlazor.ThemeManager.Extensions;

internal static class Extension
{
    private static readonly PaletteSerializerContext PaletteSerializerContext = new();
    private static readonly ThemeSerializerContext ThemeSerializerContext = new();

    public static MudTheme DeepClone(this MudTheme source)
    {
        var themeType = typeof(MudTheme);
        var serializeStr = JsonSerializer.Serialize(source, themeType, ThemeSerializerContext);
        var copyObj = (MudTheme?)JsonSerializer.Deserialize(serializeStr, themeType, ThemeSerializerContext);

        return copyObj ?? new MudTheme();
    }

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