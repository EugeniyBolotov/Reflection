
using Reflection.Abstractions;
using Reflection.Implementations;
using Reflection.Implementatnions;
using Reflection.Properties;
using System.Diagnostics;


IInput input = new ConsoleInput();
IOutput output = new ConsoleOutput();

List<long> jsonSerializationExecutionTimeResults = new List<long>();
List<long> csvSerializationExecutionTimeResults = new List<long>();

List<long> jsonDeserializationExecutionTimeResults = new List<long>();
List<long> csvDeserializationExecutionTimeResults = new List<long>();

List<string> jsonSerializeResults = new List<string>();
List<string> csvSerializeResults = new List<string>();

ISerialization jsonSerialization = new JsonSerializer();
ISerialization csvSerializer = new CsvSerializer();

IDeserialization jsonDeserialization = new JsonDeserializer();
IDeserialization csvDeserialization = new CsvDeserializer();

F f = F.Get();
Stopwatch stopwatch = new Stopwatch();

var data = "";

TimeSpan executionTime = TimeSpan.FromSeconds(0);

//Json serialization
stopwatch.Start();
for (int i = 0; i < 10000; i++)
{
    data = jsonSerialization.Serialize(f);
}
stopwatch.Stop();
executionTime = stopwatch.Elapsed;
stopwatch.Restart();
stopwatch.Start();
Console.WriteLine($"Json serialization: {data}");
stopwatch.Stop();
Console.WriteLine($"Json serialization time: {executionTime.Milliseconds} ms");
executionTime = stopwatch.Elapsed;
Console.WriteLine($"Json console output time: {executionTime.Milliseconds} ms");

//Json deserialization
F? deserializedF = new F();
stopwatch.Restart();
stopwatch.Start();
for (int i = 0; i < 10000; i++)
{
    deserializedF = jsonDeserialization.Deserialize<F>(data);
}
stopwatch.Stop();
executionTime = stopwatch.Elapsed;
Console.WriteLine($"Json deserialization time: {executionTime.Milliseconds} ms");

Console.WriteLine($"\n\n");
stopwatch.Restart();
//CSV serialization
stopwatch.Start();
for (int i = 0; i < 10000; i++)
{
    data = csvSerializer.Serialize(f);
}
stopwatch.Stop();
executionTime = stopwatch.Elapsed;
stopwatch.Restart();
stopwatch.Start();
Console.WriteLine($"CSV serialization: {data}");
stopwatch.Stop();
Console.WriteLine($"CSV serialization time: {executionTime.Milliseconds} ms");
executionTime = stopwatch.Elapsed;
Console.WriteLine($"CSV console output time: {executionTime.Milliseconds} ms");

//Json deserialization
stopwatch.Restart();
stopwatch.Start();
for (int i = 0; i < 10000; i++)
{
    deserializedF = csvDeserialization.Deserialize<F>(data);
}
stopwatch.Stop();
executionTime = stopwatch.Elapsed;
Console.WriteLine($"CSV deserialization time: {executionTime.Milliseconds} ms");