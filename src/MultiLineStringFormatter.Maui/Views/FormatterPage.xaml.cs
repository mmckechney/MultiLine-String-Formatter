namespace MultiLineStringFormatter.Maui.Views;

public partial class FormatterPage : ContentPage
{
    public FormatterPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// WinUI3's native TextBox ignores VerticalOptions="Fill" on MAUI Editor.
    /// We explicitly set HeightRequest on the Editor to match the Border's actual height,
    /// forcing the text input area to fill the entire visible area.
    /// </summary>
    private void OnEditorBorderSizeChanged(object? sender, EventArgs e)
    {
        if (sender is Border border && border.Content is Editor editor && border.Height > 0)
        {
            var availableHeight = border.Height - border.Padding.VerticalThickness - (border.StrokeThickness * 2);
            if (availableHeight > 0)
            {
                editor.HeightRequest = availableHeight;
            }
        }
    }
}
