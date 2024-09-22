using Reflection.Abstractions;
using Reflection.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Implementations
{
    internal class DeserializationExecutionTimer: IOperationExecutionTimer
    {
        IDeserialization deserialization;
        string objectForDeserialization;
        public DeserializationExecutionTimer( IDeserialization deserialization, string objectForDeserialization)
        {
            this.deserialization = deserialization;
            this.objectForDeserialization = objectForDeserialization;
        }

        public long MeasureExecutionTime()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            F deserializedData = deserialization.Deserialize<F>(objectForDeserialization);

            stopwatch.Stop();
            long deserializationTime = stopwatch.ElapsedMilliseconds;

            return deserializationTime;
        }

        public long MeasureExecutionTime(out string data)
        {
            throw new NotImplementedException();
        }
    }
}
