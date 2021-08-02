using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Multiplier : IAlgorithm
    {
        private ILogger _logger;

        public Multiplier(ILogger logger)
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
            Logger.LogInformation("Multiplier calculate start.");

            return first * second;
        }
    }
}
