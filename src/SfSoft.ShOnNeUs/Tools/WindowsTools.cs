using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace SfSoft.ShOnNeUs.Tools
{
	public class WindowsTools
	{
		//public void ShutdownWindows()
		//{
		//	var shutdownProcess = new ProcessStartInfo("shutdown", "/s /t 0")
		//	{
		//		CreateNoWindow = true,
		//		UseShellExecute = false
		//	};
		//	Process.Start(shutdownProcess);
		//}

		//CREDIT: http://www.geekpedia.com/code36_Shut-down-system-using-Csharp.html
		public void Shutdown()
		{
			var mcWin32 = new ManagementClass("Win32_OperatingSystem");
			mcWin32.Get();

			// You can't shutdown without security privileges
			mcWin32.Scope.Options.EnablePrivileges = true;
			var mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");

			// Flag 1 means we want to shut down the system. Use "2" to reboot.
			mboShutdownParams["Flags"] = "1";
			mboShutdownParams["Reserved"] = "0";
			foreach (var manObj in mcWin32.GetInstances().Cast<ManagementObject>())
			{
				manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
			}
		}

		public List<string> GetNetworkInterfaces()
		{
			return NetworkInterface.GetAllNetworkInterfaces()
				.Where(t => t.OperationalStatus == OperationalStatus.Up)
				.Select(t => t.Name).ToList();
		}

		public void GetNetworkUsage(List<string> interfacesToCheck)
		{
			foreach (
				var ni in NetworkInterface.GetAllNetworkInterfaces().Where(t => t.OperationalStatus == OperationalStatus.Up &&
				                                                                interfacesToCheck.Contains(t.Name)))
			{
				//ni.GetIPv4Statistics().BytesSent);
				//ni.GetIPv4Statistics().BytesReceived);
			}
		}

		#region GetLastInputInfo
		[DllImport("user32.dll")]
		static extern bool GetLastInputInfo(ref Lastinputinfo plii);

		public uint GetLastInputTime()
		{
			uint idleTime = 0;
			var lastInputInfo = new Lastinputinfo();
			lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
			lastInputInfo.dwTime = 0;

			var envTicks = (uint)Environment.TickCount;

			if (!GetLastInputInfo(ref lastInputInfo))
			{
				return ((idleTime > 0) ? (idleTime / 1000) : 0);
			}

			var lastInputTick = lastInputInfo.dwTime;

			idleTime = envTicks - lastInputTick;

			return ((idleTime > 0) ? (idleTime / 1000) : 0);
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct Lastinputinfo
		{
			private static readonly int SizeOf = Marshal.SizeOf(typeof(Lastinputinfo));

			[MarshalAs(UnmanagedType.U4)]
			public uint cbSize;
			[MarshalAs(UnmanagedType.U4)]
			public uint dwTime;
		}
		#endregion GetLastInputInfo
	}
}