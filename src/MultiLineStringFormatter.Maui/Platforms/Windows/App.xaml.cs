using Microsoft.UI.Xaml;

namespace MultiLineStringFormatter.Maui.WinUI;

public partial class App : MauiWinUIApplication
{
	public App()
	{
		this.InitializeComponent();
		this.UnhandledException += OnUnhandledException;
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	private void OnUnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
	{
		var logPath = System.IO.Path.Combine(
			System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
			"MultiLineStringFormatter", "maui-crash.log");
		System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(logPath)!);
		System.IO.File.WriteAllText(logPath, $"{System.DateTime.Now}: {e.Exception}\n{e.Exception.StackTrace}");
		e.Handled = true;
	}
}

