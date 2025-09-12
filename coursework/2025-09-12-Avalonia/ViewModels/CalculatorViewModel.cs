using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _2025_09_12_Avalonia.ViewModels;

public partial class CalculatorViewModel : ViewModelBase
{
    public double FirstNumber { get; set; } = 99;
    public double SecondNumber { get; set; } = 1;
    // Wenn eine Änderung in C# einen Refresh vom UI braucht, so macht man eine ObservableProperty daraus
    [ObservableProperty] private double result = 0;
    public string SelectedOperator { get; set; } = "+";
    public ObservableCollection<string> Operators { get; } = ["+", "-", "*", "/"];

    // Wenn eine Methode vom UI aufgerufen werden soll, so macht man eine RelayCommand daraus
    [RelayCommand]
    private void Calculate()
    {
        Result = SelectedOperator switch
        {
            "+" => FirstNumber + SecondNumber,
            "-" => FirstNumber - SecondNumber,
            "*" => FirstNumber * SecondNumber,
            "/" => FirstNumber / SecondNumber,
            _ => throw new NotImplementedException("Unknown operator")
        };
    }
}