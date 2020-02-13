using DnsUpdater.Core;
using FluentScheduler;
using System.ServiceProcess;

namespace DnsUpdater
{
	public class DnsService : ServiceBase
	{
		public DnsService()
		{
			ServiceName = "DnsService";
		}

		public void Start(string[] args)
		{
			OnStart(args);
		}

		protected override void OnStart(string[] args)
		{
			JobManager.Initialize(new JobRegistry());
		}

		public void Finish()
		{
			OnStop();
		}

		protected override void OnStop()
		{
			JobManager.StopAndBlock();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose other resources
			}
			base.Dispose(disposing);
		}
	}
}
