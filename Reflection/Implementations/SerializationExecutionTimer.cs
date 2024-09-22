using Newtonsoft.Json;
using Reflection.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.Properties;

namespace Reflection.Implementations
{
    internal class SerializationExecutionTimer<T> where T: class, IOperationExecutionTimer
    {
        ISerialization serialization;
        T objectForSerialization;
        public SerializationExecutionTimer(ISerialization serialization, T objectForSerialization)
        {
            this.serialization = serialization;
            this.objectForSerialization = objectForSerialization;
        }
        public long MeasureExecutionTime(out string serializedData)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            serializedData = serialization.Serialize(objectForSerialization);

            stopwatch.Stop();
            long serializationTime = stopwatch.ElapsedMilliseconds;

            return serializationTime;
        }
        public long MeasureExecutionTime()
        {
            throw new NotImplementedException();
        }
    }
}
