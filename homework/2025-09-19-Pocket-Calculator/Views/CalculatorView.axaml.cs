using _2025_09_19_Pocket_Calculator.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace _2025_09_19_Pocket_Calculator.Views;

public partial class CalculatorView : Window
{
    public CalculatorView()
    {
        InitializeComponent();
        DataContext = new CalculatorViewModel();
    }
}