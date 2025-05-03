using System;
using System.Linq;

namespace EasyCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 3)
                {
                    Console.WriteLine("Ошибка: должно быть ровно три значения.");
                }
                else
                {
                    int a = int.Parse(parts[0]);
                    char operation = char.Parse(parts[1]);
                    int b = int.Parse(parts[2]);
                    int c = 0;
                    switch (operation)
                    {
                        case '+':
                            c = a + b;
                            break;
                        case '-':
                            c = a - b;
                            break;
                        case '*':
                            c = a * b;
                            break;
                        case '/':
                            if (b == 0)
                            {
                                Console.WriteLine("Я провожу проверку деления на ноль");
                            }
                            else
                            {
                                c = a / b;
                            }
                            break;
                        case 'q':
                            return;
                        default:
                            Console.WriteLine("Нет, такой операции");
                            break;
                    }
                    Console.WriteLine($"Ответ: {c}");
                }
            }
        }
    }
}