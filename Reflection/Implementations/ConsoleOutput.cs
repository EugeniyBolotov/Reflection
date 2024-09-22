using Reflection.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Implementations
{
    internal class ConsoleOutput: IOutput
    {
        public void PrintValue(string value) 
        {
            Console.WriteLine(value);
        }
    }
}
