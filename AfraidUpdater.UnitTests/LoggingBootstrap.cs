namespace DnsUpdater.UnitTests
{
    public static class LoggingBootstrap
    {
        private static bool isBootStrapped;

        public static void BootStrap()
        {
            if (isBootStrapped) return;

            log4net.Config.XmlConfigurator.Configure();
            isBootStrapped = true;
        }
    }
}
