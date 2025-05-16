using System;
using System.Data;

class Program
{
    static void Main()
    {
        Console.Write("Введите выражение: ");
        string input = Console.ReadLine();

        try
        {
            var result = EvaluateExpression(input);
            Console.WriteLine("Результат: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    static double EvaluateExpression(string expression)
    {
        string fix_exp = "";
        foreach (char c in expression)
        {
            if ("0123456789+-*/(). ".IndexOf(c) == -1)
                throw new FormatException($"Недопустимый символ: {c}");
            if (c!=' ')
            {
                fix_exp += c;
            }
        }
        var table = new DataTable();
        var result = table.Compute(fix_exp, "");

        return Convert.ToDouble(result);
    }
}