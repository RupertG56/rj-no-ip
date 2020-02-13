using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DnsUpdater.UnitTests
{
    [TestClass]
    public class UpdaterTest
    {
        static UpdaterTest()
        {
            LoggingBootstrap.BootStrap();
        }

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(UpdaterTest));

        [TestMethod]
        public async Task Update()
        {
            Core.AfraidUpdater updater = new Core.AfraidUpdater();

            await updater.Update();
        }
    }
}
