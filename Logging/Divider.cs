using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Divider : IAlgorithm
    {
        private ILogger _logger;

        public Divider(ILogger logger)
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
                result = first / second;
                return result;
            }
            catch (Exception e)
            {
                Logger.LogCritical("An unexpected error occurred at the time of the division.", e);
            }

            return 0;
        }
    }
}
