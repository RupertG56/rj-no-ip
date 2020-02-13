using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentScheduler;

namespace DnsUpdater.Core
{
	public class JobRegistry : Registry
	{
		public JobRegistry()
		{
			//Schedule<UpdaterJob>().ToRunNow().AndEvery(1).Weeks().On(DayOfWeek.Sunday).At(0, 0);
			Schedule<AfraidUpdaterJob>().ToRunNow().AndEvery(1).Days().At(0, 0);
		}
	}
}
