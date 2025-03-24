using System;
using CalculatorApp;

class Program
{
    static void Main()
    {
        var calculator = new Calculator();

        // Test the Add function
        Console.WriteLine($"Add(5, 2.4) = {calculator.Add(5, 2.4)}");  // Expected output: 7.4

        // Test the Subtract function
        Console.WriteLine($"Subtract(5, 2.4) = {calculator.Subtract(5, 2.4)}");  // Expected output: 2.6

        // Test the Multiply function
        Console.WriteLine($"Multiply(5, 2.4) = {calculator.Multiply(5, 2.4)}");  // Expected output: 12

        // Test the Power function
        Console.WriteLine($"Power(5, 2) = {calculator.Power(5, 2)}");  // Expected output: 25
    }
}