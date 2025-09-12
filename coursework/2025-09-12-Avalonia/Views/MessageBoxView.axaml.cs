using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace _2025_09_12_Avalonia.Views;

public partial class MessageBoxView : UserControl
{
    public MessageBoxView()
    {
        InitializeComponent();
    }

    private async void OnLaunchMessageBoxClick(object? sender, RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Information",
            "This is a simple message box!",
            ButtonEnum.Ok);

        await box.ShowAsync();
    }
}