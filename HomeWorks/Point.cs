using System;

using System;

namespace PointApp
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Перегрузка оператора '-', возвращает расстояние между двумя точками
        public static double operator -(Point p1, Point p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentNullException();

            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Point p1 = new Point(3, 4);
    //        Point p2 = new Point(0, 0);

    //        double distance = p1 - p2;

    //        Console.WriteLine($"Расстояние между точками {p1} и {p2} равно {distance:F2}");
    //    }
    //}
}