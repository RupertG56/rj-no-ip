using DnsUpdater.Core;
using System;
using System.ServiceProcess;

namespace DnsUpdater
{
	static class Program
    {
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                try
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                        new DnsService()
                    };
                    ServiceBase.Run(ServicesToRun);
					return;
                }
				catch (Exception e)
				{
					Log.Error("Application is ending due to an unexpected exception.", e);
				}
			}

			var argSwitch = args[0].SafeToUpper();
			if (argSwitch != "CONSOLE")
			{
				Log.Info("Invalid args to run as console application");
				return;
			}

			DnsService service = new DnsService();

			try
			{
				service.Start(null);

				Log.Info($"Service {service.ServiceName} started!");
				Console.WriteLine("Press q to quit...");

				while (true)
				{
					var key = Console.ReadKey();
					if (key.KeyChar != 'q')
					{
						Console.WriteLine("No! Press q to quit...");
						continue;
					}

					service.Finish();
					Console.WriteLine("Bye");
					break;
				}
			}
			catch (Exception e)
			{
				Log.Error("Application is ending due to an unexpected exception.", e);
			}
		}
    }
}
