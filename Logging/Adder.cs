using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Adder : IAlgorithm
    {
        private ILogger _logger;

        public Adder(ILogger logger)
        {
            this.Logger = logger;
        }

        public ILogger Logger
        {
            get => _logger;
            set => _logger = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Calculate(int first, int second)
        {
            Logger.LogInformation("Adder calculate start.");

            int result;

            try
            {
                result = checked(first + second);
            }
            catch (OverflowException)
            {
                Logger.LogInformation("Overflow occurred during addition");
            }
            catch
            {
                Logger.LogWarning("An unknown error occurred during the addition.");
            }
            finally
            {
                result = unchecked(first + second);
            }

            return result;
        }
    }
}
