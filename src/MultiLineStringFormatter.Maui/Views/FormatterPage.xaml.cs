namespace MultiLineStringFormatter.Maui.Views;

public partial class FormatterPage : ContentPage
{
    public FormatterPage()
    {
        InitializeComponent();
        SizeChanged += OnPageSizeChanged;
    }

    private void OnPageSizeChanged(object? sender, EventArgs e)
    {
        // Force editors to re-measure when the page resizes.
        // WinUI3's TextBox doesn't always respond to parent size changes,
        // so we invalidate the layout to ensure editors fill their cells.
        SourceEditor?.InvalidateMeasure();
        FormatEditor?.InvalidateMeasure();
        ResultsEditor?.InvalidateMeasure();
        MainGrid?.InvalidateMeasure();
    }
}
