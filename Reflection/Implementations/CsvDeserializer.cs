using Reflection.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Implementatnions
{
    internal class CsvDeserializer : IDeserialization
    {
        public T Deserialize<T>(string data) where T : new()
        {
            T obj = new T();
            string[] pairs = data.Split(';');
            foreach (string pair in pairs)
            {
                string[] parts = pair.Split('=');
                if (parts.Length != 2) continue;
                string propertyName = parts[0].Trim();
                string propertyValue = parts[1].Trim();
                PropertyInfo property = typeof(T).GetProperty(propertyName);
                if (property != null)
                {
                    property.SetValue(obj, Convert.ChangeType(propertyValue, property.PropertyType));
                }
            }
            return obj;
        }
    }
}
