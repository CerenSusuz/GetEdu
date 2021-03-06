using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BaseCore.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object source)
        {
            return JsonConvert.SerializeObject(source, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static T FromJson<T>(this string source) where T : new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(source);
            }
            catch
            {
                return new T();
            }
        }
    }
}