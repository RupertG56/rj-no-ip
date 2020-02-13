using FluentScheduler;
using log4net;
using System.Threading.Tasks;

namespace DnsUpdater.Core
{
    class AfraidUpdaterJob : IJob
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AfraidUpdaterJob));
        private static readonly AfraidUpdater updater = new AfraidUpdater();

        public void Execute()
        {
            Log.Debug("Executing job...");

            Task.WhenAll(updater.Update()).ContinueWith(t => Log.Debug("Execution complete..."));
        }
    }
}
