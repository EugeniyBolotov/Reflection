using Reflection.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Implementatnions
{
    internal class CsvSerializer : ISerialization
    {
        public string Serialize<T>(T obj)
        {
            StringBuilder csvData = new StringBuilder();

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                csvData.Append($"{property.Name}={property.GetValue(obj)}; ");
            }

            return csvData.ToString();
        }
    }
}
