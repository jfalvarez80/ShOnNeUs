using System;
using System.Runtime.InteropServices;
using SfSoft.ShOnNeUs.Resources;

namespace SfSoft.ShOnNeUs
{
	public static class Program
	{
		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		static extern bool FreeConsole();

		[STAThread]
		public static int Main(string[] args)
		{
			if (args != null && args.Length > 0)
			{
				Console.WriteLine(LocalizedStrings.Program_Main_Hello_world);
				Console.ReadLine();
				return 0;
			}

			FreeConsole();
			var app = new App();
			return app.Run();
		}
	}
}