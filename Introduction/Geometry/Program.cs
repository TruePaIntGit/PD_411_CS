using System;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите:\n1 - квадрат\n2 - треугольник\n3 - горизонтально отраженный треугольник\n4 - перевёрнутый треугольник\n5 - вертикально отражённый треугольник\n6 - ромб\n7 - шахматная доска\nq - выход");
                string code = Console.ReadLine();
                switch (code)
                {
                    case "1":
                        square_p();
                        break;
                    case "2":
                        triangle_p();
                        break;
                    case "3":
                        triangle_h_p();
                        break;
                    case "4":
                        triangle_h_v_p();
                        break;
                    case "5":
                        triangle_v_p();
                        break;
                    case "6":
                        rombe_p();
                        break;
                    case "7":
                        chests_p();
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Нет такой операции");
                        break;
                }
            }
        }
        static string Repeat(string text, int times)
        {
            string repeated = "";
            while (times>0)
            {
                repeated += text;
                times--;
            }
            return repeated;
        }
        static void square_p(int a = 5)
        {
            for (int i = 0; i < a; i++)
            {
                string line = "";
                for (int j = 0; j < a; j++)
                {
                    line += " *";
                }
                Console.WriteLine(line);
            }
        }
        static void triangle_p()
        {
            string figure = "\t*\r\n\t* * \r\n\t* * * \r\n\t* * * *\r\n\t* * * * *";
            Console.WriteLine(figure);
        }
        static void triangle_h_p()
        {
            string figure = "\t* * * * *\r\n\t* * * *\r\n\t* * *\r\n\t* *\r\n\t*";
            Console.WriteLine(figure);
        }
        static void triangle_h_v_p()
        {
            string figure = "\t* * * * *\r\n\t  * * * *\r\n\t    * * *\r\n\t      * *\r\n\t\t*";
            Console.WriteLine(figure);
        }
        static void triangle_v_p()
        {
            string figure = "\t\t*\r\n\t      * *\r\n\t    * * *\r\n\t  * * * *\r\n\t* * * * *";
            Console.WriteLine(figure);
        }
        static void rombe_p(int size = 10)
        {
            for (int i = 0; i<size; i++)
            {
                if (i < size/2)
                {
                    Console.WriteLine(Repeat(" ", (size / 2) - 1 - i) + '/' + Repeat(" ", (i * 2)) + '\\');
                }
                else
                {
                    Console.WriteLine(Repeat(" ", i- (size / 2)) + '\\' + Repeat(" ", ((i-size) * -2)-2) + '/');
                }
            }
        }
        static void chests_p(int size = 5) 
        {
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if (i%2 == 0)
                    {
                        Console.WriteLine(Repeat("* ", size)+Repeat("  ",size)+ Repeat("* ", size) + Repeat("  ", size)+ Repeat("* ", size) + Repeat("  ", size)+ Repeat("* ", size) + Repeat("  ", size));
                    }
                    else
                    {
                        Console.WriteLine(Repeat("  ", size) + Repeat("* ", size) + Repeat("  ", size) + Repeat("* ", size) + Repeat("  ", size) + Repeat("* ", size) + Repeat("  ", size) + Repeat("* ", size));
                    }
                }

            }
        }
    }
}