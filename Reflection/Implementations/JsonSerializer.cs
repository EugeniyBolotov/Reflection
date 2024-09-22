using Reflection.Abstractions;
using Newtonsoft.Json;

namespace Reflection.Implementations
{
    internal class JsonSerializer: ISerialization
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
