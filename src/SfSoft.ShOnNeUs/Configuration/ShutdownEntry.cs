using System.Collections.Generic;
using SfSoft.ShOnNeUs.Enums;

namespace SfSoft.ShOnNeUs.Configuration
{
	public class ShutdownEntry
	{
		/// <summary>
		/// Measure units for MeasureQuantity
		/// </summary>
		public MeasureUnit MeasureUnit { get; set; }

		/// <summary>
		/// Units of MeasureUnit. If below, shutdown, if above, do nothing
		/// </summary>
		public int MeasureQuantity { get; set; }

		public int PoolingInterval { get; set; }

		/// <summary>
		/// The number of consecutive network usage success count before shutting down windows
		/// </summary>
		public int PoolingSuccessCount { get; set; }

		/// <summary>
		/// List of windows processes that will stop windows from shuttingdown even if success is meet
		/// </summary>
		public List<string> NotRunningProcesses { get; set; }

		/// <summary>
		/// Before shutdown, should we check for user inactivity?
		/// </summary>
		public bool CheckForInactivity { get; set; }

		/// <summary>
		/// Won't check all network interfaces, only specified ones
		/// </summary>
		public List<string> NetworkInterfacesToCheck { get; set; }
	}
}