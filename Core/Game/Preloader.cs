using System.Runtime.InteropServices;

namespace Edge_Of_Plain.Core.Game;

public static class Preloader
{
	public static void PreloadGame()
	{
		if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Global.GetGlobal().OsPlatformId = 0;
		if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) Global.GetGlobal().OsPlatformId = 1;
		if(RuntimeInformation.IsOSPlatform(OSPlatform.Create("Android"))) Global.GetGlobal().OsPlatformId = 2;
		GetSettings();
	}

	private static void GetSettings()
	{
		Global.GetGlobal().GamePath = Global.GetGlobal().OsPlatformId switch
		{
			0 => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\StarsSailing\EdgeOfPlain\",
			1 => "/usr/local/share/StarSailing/EdgeOfPlain/",
			2 => "/storage/emulated/0/StarSailing/EdgeOfPlain/",
			_ => Global.GetGlobal().GamePath
		};
	}
}