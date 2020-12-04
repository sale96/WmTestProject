using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application;

namespace WmTestProject.Implementation.Loggers
{
    public class ConsoleLogger : IApplicationLogger
    {
        public void Log(string name, object data)
        {
            var msg = $"{name} is executed with the data {JsonConvert.SerializeObject(data)}";
            Console.WriteLine(msg);
        }
    }
}
