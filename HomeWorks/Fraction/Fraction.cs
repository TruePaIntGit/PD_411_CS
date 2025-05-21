using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math;

namespace Math
{
    public class Fraction
    {
        public int Numerator { get; }     // Числитель
        public int Denominator { get; }   // Знаменатель

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Ошибка: Деление на 0");

            // Обработка отрицательного знаменателя
            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }

            // Упрощение дроби
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // --- Перегрузка операторов ---

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            int denominator = f1.Denominator * f2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            int denominator = f1.Denominator * f2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Numerator;
            int denominator = f1.Denominator * f2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.Numerator == 0)
                throw new DivideByZeroException("Ошбика: Деление на 0.");

            return new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
        }

        // --- Сравнение дробей ---
        public override bool Equals(object obj) => Equals(obj as Fraction);

        public bool Equals(Fraction other)
        {
            if (other is null) return false;
            // Приведение к общему знаменателю для сравнения
            return Numerator * other.Denominator == other.Numerator * Denominator;
        }

        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        public static bool operator ==(Fraction left, Fraction right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(Fraction left, Fraction right) => !(left == right);

        // --- Сравнение больше/меньше ---
        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator > f2.Numerator * f1.Denominator;
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator < f2.Numerator * f1.Denominator;
        }

        public static bool operator >=(Fraction f1, Fraction f2) => !(f1 < f2);
        public static bool operator <=(Fraction f1, Fraction f2) => !(f1 > f2);

        // --- Преобразования ---
        public static implicit operator double(Fraction f) => (double)f.Numerator / f.Denominator;

        public static explicit operator Fraction(int value) => new Fraction(value, 1);

        // --- Вывод ---
        public override string ToString()
        {
            if (Denominator == 1)
                return $"{Numerator}";
            return $"{Numerator}/{Denominator}";
        }
    }
}

