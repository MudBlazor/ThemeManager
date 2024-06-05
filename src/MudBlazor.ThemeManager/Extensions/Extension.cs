using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            else
            {
                return default(T);
            }

        }
    }
}
