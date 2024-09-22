﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Abstractions
{
    internal interface IDeserialization
    {
        T Deserialize<T>(string data) where T : new();
    }
}
