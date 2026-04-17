using Microsoft.Extensions.Logging;
using MultiLineStringFormatter.Maui.ViewModels;
using MultiLineStringFormatter.Maui.Views;

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
