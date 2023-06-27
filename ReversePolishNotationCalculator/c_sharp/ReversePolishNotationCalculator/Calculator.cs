using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversePolishNotationCalculator;

public static class Calculator
{
    public static double Solve(string calculation)
    {
        var tokens = SplitCalculationStringIntoTokens(calculation);
        var result = TryParseDouble(tokens.Dequeue());

        while (tokens.Any())
        {
            if (tokens.Count < 2)
            {
                throw new ArgumentException("Invalid number of parameters in calculation!");
            }

            result = Calculate(
                result,
                TryParseDouble(tokens.Dequeue()),
                tokens.Dequeue());
        }

        return result;
    }

    private static double TryParseDouble(string doubleAsString)
    {
        return double.TryParse(doubleAsString, out var result)
            ? result
            : throw new ArgumentException($"Value {doubleAsString} is not a valid number!");
    }

    private static Queue<string> SplitCalculationStringIntoTokens(string calculation)
    {
        var tokens = calculation
            .Split(' ')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x))
            .ToList();

        if (!tokens.Any())
        {
            throw new ArgumentException("Calculation must not empty!");
        }

        return new Queue<string>(tokens);
    }

    private static double Calculate(double firstOperand, double secondOperand, string operation)
    {
        return operation switch
        {
            "+" => firstOperand + secondOperand,
            "-" => firstOperand - secondOperand,
            "*" => firstOperand * secondOperand, //optional
            "/" => firstOperand / secondOperand, //optional
            _ => throw new ArgumentException($"Unknown operator {operation}")
        };
    }
}
