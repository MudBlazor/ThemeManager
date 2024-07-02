using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace MudBlazor.ThemeManager.Extensions;

internal static class Extension
{
    private static readonly JsonSerializerOptions JsonOptions = new();

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
}