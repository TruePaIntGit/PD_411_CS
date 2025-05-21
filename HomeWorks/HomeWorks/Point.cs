using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    public class Point : IEquatable<Point>
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // --- Расстояние ---
        public static double operator -(Point p1, Point p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentNullException();

            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // --- Сложение ---
        public static Point operator +(Point p1, Point p2) =>
            new Point(p1.X + p2.X, p1.Y + p2.Y);

        // --- Умножение на число ---
        public static Point operator *(Point p, double factor) =>
            new Point(p.X * factor, p.Y * factor);

        // --- Деление на число ---
        public static Point operator /(Point p, double divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();
            return new Point(p.X / divisor, p.Y / divisor);
        }

        // --- Равенство ---
        public bool Equals(Point other) => 
            other != null && X == other.X && Y == other.Y;

        public override bool Equals(object obj) => 
            Equals(obj as Point);

        public static bool operator ==(Point left, Point right) => 
            Equals(left, right);

        public static bool operator !=(Point left, Point right) => 
            !Equals(left, right);

        // --- Форматированный вывод ---
        public override string ToString() => 
            $"({X}, {Y})";

        public string ToString(string format) => 
            $"({X.ToString(format)}, {Y.ToString(format)})";

        // --- Движение точки ---
        public Point Move(double deltaX, double deltaY) => 
            new Point(X + deltaX, Y + deltaY);

        // --- Середина между двумя точками ---
        public static Point Midpoint(Point p1, Point p2) => 
            new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

        // --- Перемещение ---
        public Point MoveTo(double X, double Y) =>
            new Point(X, Y);
    }
}
