using Microsoft.Extensions.DependencyInjection;

namespace MultiLineStringFormatter.Maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		AppDomain.CurrentDomain.UnhandledException += (s, e) =>
		{
			var logPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				"MultiLineStringFormatter", "maui-crash.log");
			Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);
			File.AppendAllText(logPath, $"\n{DateTime.Now} AppDomain: {e.ExceptionObject}\n");
		};
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		try
		{
			var window = new Window(new AppShell());

#if WINDOWS
			// Window.Height is in DIPs. At 150% DPI, 1 DIP = 1.5 physical pixels.
			// Must ensure Height * density <= physical working area.
			var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
			var density = displayInfo.Density > 0 ? displayInfo.Density : 1.5;
			// displayInfo.Height is physical pixels
			var maxHeightDips = (displayInfo.Height - 80) / density; // 80px for taskbar
			window.Height = Math.Min(700, maxHeightDips);
			window.Width = Math.Min(1000, (displayInfo.Width - 100) / density);
#else
			window.Height = 700;
			window.Width = 1000;
#endif
			window.X = 50;
			window.Y = 0;
			return window;
		}
		catch (Exception ex)
		{
			var logPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				"MultiLineStringFormatter", "maui-crash.log");
			Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);
			File.AppendAllText(logPath, $"\n{DateTime.Now} CreateWindow: {ex}\n");
			throw;
		}
	}
}