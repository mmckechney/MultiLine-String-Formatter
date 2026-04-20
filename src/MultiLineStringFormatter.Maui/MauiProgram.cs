using Microsoft.Extensions.Logging;
using MultiLineStringFormatter.Maui.ViewModels;
using MultiLineStringFormatter.Maui.Views;
#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using WinRT.Interop;
#endif

namespace MultiLineStringFormatter.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if WINDOWS
		builder.ConfigureLifecycleEvents(events =>
		{
			events.AddWindows(windows => windows.OnWindowCreated(window =>
			{
				try
				{
					var hwnd = WindowNative.GetWindowHandle(window);
					var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
					var appWindow = AppWindow.GetFromWindowId(windowId);
					var iconPath = Path.Combine(AppContext.BaseDirectory, "windowicon.ico");
					if (File.Exists(iconPath))
					{
						appWindow.SetIcon(iconPath);
					}
				}
				catch
				{
					// Non-fatal: window will just use the default icon.
				}
			}));
		});
#endif

		// Register pages
		builder.Services.AddTransient<FormatterPage>();
		builder.Services.AddTransient<AnalysisPage>();
		builder.Services.AddTransient<FileTrimmerPage>();

		// Register view models
		builder.Services.AddTransient<FormatterViewModel>();
		builder.Services.AddTransient<AnalysisViewModel>();
		builder.Services.AddTransient<FileTrimmerViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
