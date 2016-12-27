using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfSoft.ShOnNeUs.Tools
{
	public class WindowsTools
	{
		public void ShutdownWindows()
		{
			var shutdownProcess = new ProcessStartInfo("shutdown", "/s /t 0")
			{
				CreateNoWindow = true,
				UseShellExecute = false
			};
			Process.Start(shutdownProcess);
		}
	}
}