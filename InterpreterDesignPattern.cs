using System;
using System.Collections.Generic;

// Context
class CombinedContext
{
    public Dictionary<string, int> Variables { get; private set; }
    public Dictionary<char, int> RomanNumerals { get; private set; }

    public CombinedContext()
    {
        Variables = new Dictionary<string, int>();
        RomanNumerals = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
    }

    public void SetVariable(string variable, int value)
    {
        Variables[variable] = value;
    }

    public int GetVariable(string variable)
    {
        if (Variables.ContainsKey(variable))
        {
            return Variables[variable];
        }
        throw new ArgumentException($"Variable {variable} not found.");
    }
}

// Abstract Expression
interface ICombinedExpression
{
    int Interpret(CombinedContext context);
}

// Terminal Expression
class CombinedNumberExpression : ICombinedExpression
{
    private int value;

    public CombinedNumberExpression(int value)
    {
        this.value = value;
    }

    public int Interpret(CombinedContext context)
    {
        return value;
    }
}

// Terminal Expression
class CombinedVariableExpression : ICombinedExpression
{
    private string variable;

    public CombinedVariableExpression(string variable)
    {
        this.variable = variable;
    }

    public int Interpret(CombinedContext context)
    {
        return context.GetVariable(variable);
    }
}

// Terminal Expression
class CombinedRomanDigitExpression : ICombinedExpression
{
    private char symbol;

    public CombinedRomanDigitExpression(char symbol)
    {
        this.symbol = symbol;
    }

    public int Interpret(CombinedContext context)
    {
        return context.RomanNumerals[symbol];
    }
}

// Non-terminal Expression
class CombinedAdditionExpression : ICombinedExpression
{
    private ICombinedExpression left;
    private ICombinedExpression right;

    public CombinedAdditionExpression(ICombinedExpression left, ICombinedExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public int Interpret(CombinedContext context)
    {
        return left.Interpret(context) + right.Interpret(context);
    }
}

// Non-terminal Expression
class CombinedRomanNumberExpression : ICombinedExpression
{
    private List<ICombinedExpression> parts = new List<ICombinedExpression>();

    public void AddPart(ICombinedExpression part)
    {
        parts.Add(part);
    }

    public int Interpret(CombinedContext context)
    {
        int result = 0;
        foreach (var part in parts)
        {
            result += part.Interpret(context);
        }
        return result;
    }
}

