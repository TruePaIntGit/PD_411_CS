using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockMove
{
    class Program
    {
        static void Main()
        {

            int x = 10;
            int y = 5;
            const char CursorChar = '@';
            const char FieldChar = '.';

            while (true)
            {
                DrawField(x, y, CursorChar, FieldChar);

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        y = Math.Max(0, y - 1);
                        break;
                    case ConsoleKey.S:
                        y = Math.Min(20-1, y + 1); // ограничение по высоте
                        break;
                    case ConsoleKey.A:
                        x = Math.Max(0, x - 1);
                        break;
                    case ConsoleKey.D:
                        x = Math.Min(40-1, x + 1); // ограничение по ширине
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        static void DrawField(int cursorX, int cursorY, char cursorChar, char FieldChar)
        {
            Console.Clear();

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 40; x++)
                {
                    if (x == cursorX && y == cursorY)
                    {
                        Console.Write(cursorChar);
                    }
                    else
                    {
                        Console.Write(FieldChar);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}