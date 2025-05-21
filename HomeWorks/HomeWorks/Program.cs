using System;

namespace HomeWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(3, 4);
            Point p2 = new Point(0, 0);

            double distance = p1 - p2;

            Console.WriteLine($"Расстояние между точками {p1} и {p2} равно {distance:F2}");
        }
    }
}