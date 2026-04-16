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
			window.Width = 1200;
			window.Height = 800;
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