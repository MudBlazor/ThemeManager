using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace MudBlazor.ThemeManager.Extensions;

public static class Extension
{
    [RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed.")]
    public static T? DeepClone<T>(this T source)
    {
        if (source is not null)
        {
            var serializeStr = JsonSerializer.Serialize(source);
            JsonSerializerOptions options = new JsonSerializerOptions();
            var copyObj = JsonSerializer.Deserialize<T>(serializeStr, options);
            return copyObj;
        }

        return default(T);
    }
}