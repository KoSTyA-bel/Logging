using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Logging;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder
                        .AddConsole()
                        .SetMinimumLevel(LogLevel.Trace);
                });

            ILogger logger = loggerFactory.CreateLogger("Default logger");

            var adder = new Adder(logger);

            var a = adder.Calculate(1, 2);
            a = adder.Calculate(int.MaxValue, 124);
            IAlgorithm algorithm = adder;
            long time;
            a = algorithm.CalculateWithTime(int.MaxValue, 124, out time);

            var divider = new Divider(logger);

            a = divider.Calculate(1, 0);
        }
    }
}
