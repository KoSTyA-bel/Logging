using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Logging
{
    /// <summary>      
    /// Provides templates for some algorithm calculating.      
    /// </summary> 
    public interface IAlgorithm
    {
        ILogger Logger { get; }

        int Calculate(int first, int second);

        int CalculateWithTime(int first, int second, out long milliseconds)
        {
            Logger.LogInformation("CalculateWithTime start.");
            Stopwatch stopwatch = new();

            stopwatch.Start();
            Logger.LogInformation("Call the calculate method.");
            var result = Calculate(first, second);
            stopwatch.Stop();

            milliseconds = stopwatch.ElapsedMilliseconds;

            Logger.LogInformation($"CalculateWithTime end with time {milliseconds}.");

            return result;
        }
    }
}
