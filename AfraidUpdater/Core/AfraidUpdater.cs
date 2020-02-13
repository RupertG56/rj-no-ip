using log4net;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace DnsUpdater.Core
{
    public class AfraidUpdater
    {
        private const string UpdaterUrlKey = "UpdaterUrl";
        private static readonly HttpClient client;
        private static readonly ILog Log = LogManager.GetLogger(typeof(AfraidUpdater));

        private readonly string updateUrl;

        static AfraidUpdater()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept", "text/json");
        }

        public AfraidUpdater()
        {
            updateUrl = ConfigurationManager.AppSettings[UpdaterUrlKey];
        }

        public async Task Update()
        {
            try
            {
                Log.Info($"Running updater with url {updateUrl}");
                var jsonReturn = await client.GetStringAsync(updateUrl);

                Log.Info($"Data: {jsonReturn}");
            }
            catch (Exception e)
            {
                Log.Error("Exception in Update", e);
            }
        }
    }
}
