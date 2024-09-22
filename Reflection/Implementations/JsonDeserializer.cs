using Reflection.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Reflection.Implementations
{
    internal class JsonDeserializer: IDeserialization
    {
        public T Deserialize<T>(string data) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
