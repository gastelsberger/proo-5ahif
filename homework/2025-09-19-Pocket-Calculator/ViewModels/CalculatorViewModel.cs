using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _2025_09_19_Pocket_Calculator.ViewModels;

public partial class CalculatorViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _display = "0";
    
    private double _firstNumber = 0;
    private string _operation = "";
    private bool _isNewNumber = true;

    [RelayCommand]
    private void NumberPressed(string number)
    {
        if (_isNewNumber)
        {
            Display = number;
            _isNewNumber = false;
        }
        else
        {
            Display += number;
        }
    }
    
    [RelayCommand]
    private void OperatorPressed(string op)
    {
        _firstNumber = double.Parse(Display);
        _operation = op;
        _isNewNumber = true;
    }
    
    [RelayCommand]
    private void Calculate()
    {
        if (string.IsNullOrEmpty(_operation)) return;
        
        double secondNumber = double.Parse(Display);
        double result = _operation switch
        {
            "+" => _firstNumber + secondNumber,
            "-" => _firstNumber - secondNumber,
            "*" => _firstNumber * secondNumber,
            "/" => secondNumber != 0 ? _firstNumber / secondNumber : 0,
            _ => 0
        };

        if (_operation == "/" && secondNumber == 0)
        {
            Display = "Error: Cannot divide by zero";
            _firstNumber = 0;
            _operation = "";
            _isNewNumber = true;
            return;
        }
        
        Display = result.ToString();
        _operation = "";
        _isNewNumber = true;
    }
    
    [RelayCommand]
    private void Clear()
    {
        Display = "0";
        _firstNumber = 0;
        _operation = "";
        _isNewNumber = true;
    }
}