using MultiLineStringFormatter.Maui.Views;

namespace MultiLineStringFormatter.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AnalysisPage), typeof(AnalysisPage));
		Routing.RegisterRoute(nameof(FileTrimmerPage), typeof(FileTrimmerPage));
	}
}
