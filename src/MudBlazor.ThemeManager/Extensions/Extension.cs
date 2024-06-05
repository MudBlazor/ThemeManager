using System.Text.Json;

namespace MudBlazor.ThemeManager.Extensions
{
    public static class Extension
    {
        public static T DeepClone<T>(this T source)
        {
            if (source != null)
            {
                var serializeStr = JsonSerializer.Serialize(source);
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.Converters.Add(new MudColorConverter());
                var copyObj = JsonSerializer.Deserialize<T>(serializeStr, options);
                return copyObj;
            }

            return default(T);
        }
    }
}
