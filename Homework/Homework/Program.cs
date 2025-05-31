using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FiguresHierarchyUI
{
    // Абстрактный базовый класс
    // Можно будет добавить координаты в него
    public abstract class Figure
    {
        public const double PI = 3.14;
        public const double SIN60 = 0.8660254038;
        public double Square;
        public double Perimetr;
        public abstract void Draw(Graphics g);
        public abstract string GetInfo();
    }

    // Квадрат
    public class Square : Figure
    {
        public double Side { get; }
        public PointF Location { get; }

        public Square(PointF location, double side)
        {
            Location = location;
            Side = side;
            Square = side*side;
            Perimetr = side*4;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                Rectangle rect = new Rectangle(
                    (int)Location.X,
                    (int)Location.Y,
                    (int)Side,
                    (int)Side);
                g.FillRectangle(brush, rect);
            }
        }

        public override string GetInfo() => $"Квадрат:\n Сторона={Side:F2},\n Площадь={Square:F2},\n Периметр={Perimetr:F2}";
    }

    // Прямоугольник
    public class RectangleFigure : Figure
    {
        public double Width { get; }
        public double Height { get; }
        public PointF Location { get; }

        public RectangleFigure(PointF location, double width, double height)
        {
            Location = location;
            Width = width;
            Height = height;
            Square = width*height;
            Perimetr = (width+height)*2;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color.Green))
            {
                Rectangle rect = new Rectangle(
                    (int)Location.X,
                    (int)Location.Y,
                    (int)Width,
                    (int)Height);
                g.FillRectangle(brush, rect);
            }
        }

        public override string GetInfo() => $"Прямоугольник:\n Ширина={Width:F2},\n Высота={Height:F2},\n Площадь={Square:F2},\n Периметр={Perimetr:F2}";
    }

    // Круг
    public class Circle : Figure
    {
        public double Radius { get; }
        public PointF Location { get; }

        public Circle(PointF location, double radius)
        {
            Location = location;
            Radius = radius;
            Square = radius*radius* PI;
            Perimetr = 2 * radius * PI;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color.Red))
            {
                Rectangle rect = new Rectangle(
                    (int)(Location.X - Radius),
                    (int)(Location.Y - Radius),
                    (int)(Radius * 2),
                    (int)(Radius * 2));
                g.FillEllipse(brush, rect);
            }
        }

        public override string GetInfo() => $"Круг:\n Радиус={Radius:F2},\n Площадь={Square:F2},\n Периметр={Perimetr:F2}";
    }
    // Треугольник (абстрактный)
    public abstract class BaseTriangle : Figure
    {
        public Point P1 { get; }
        public Point P2 { get; }
        public Point P3 { get; }
        public PointF Location { get; }

        public BaseTriangle(Point p1, Point p2, Point p3, PointF location)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            Location = location;
        }
        public override void Draw(Graphics g)
        {

            Point[] points = { P1, P2, P3 };

            using (Brush brush = new SolidBrush(Color.Purple))
            {
                g.FillPolygon(brush, points);
            }
        }
    }

    // Треугольник (равнобедренный)
    public class IsoscelesTriangle : BaseTriangle
    {
        public double BaseLength { get; }
        public double Height { get; }
        public IsoscelesTriangle(PointF location, double baseLength, double height) : base(
            new Point((int)location.X, (int)location.Y),
            new Point((int)(location.X - baseLength / 2), (int)(location.Y + height)),
            new Point((int)(location.X + baseLength / 2), (int)(location.Y + baseLength)),
            location)
        {
            Height = height;
            BaseLength = baseLength;
            Square = baseLength * height / 2;
            Perimetr = Math.Sqrt(height*height+baseLength*baseLength)*2+baseLength;
        }
        public override string GetInfo() => $"Треугольник (равнобедренный):\n Стороны={BaseLength:F2},\n Высота={Height:F2},\n Площадь={Square:F2},\n Периметр={Perimetr:F2}";
    }

    // Треугольник (равносторонний)
    public class EquilateralTriange : BaseTriangle
    {
        public double BaseLength { get; }
        public EquilateralTriange(PointF location, double baseLength):base(
            new Point((int)location.X, (int)location.Y),
            new Point((int)(location.X - (baseLength/2)), (int)(location.Y + SIN60 *baseLength)),
            new Point((int)(location.X + (baseLength / 2)), (int)(location.Y + SIN60 * baseLength)),
            location)
        { 
            BaseLength = baseLength;
            Square = Math.Sqrt(3) * baseLength * baseLength / 4;
            Perimetr = baseLength * 3;
        }
        public override string GetInfo() => $"Треугольник (равносторонний):\n Стороны={BaseLength:F2},\n Площадь={Square:F2},\n Периметр={Perimetr:F2}";
    }

    // Сама форма
    public class MainForm : Form
    {
        private List<Figure> figures = new List<Figure>();
        private List<Label> labels = new List<Label>();
        private Random rand = new Random();

        public MainForm()
        {
            Text = "Геометрические фигуры";
            ClientSize = new Size(800, 600);
            Paint += OnPaint;

            Button button = new Button
            {
                Size = new Size(100,20),
                Text = "Сгенерировать",
                Location = new Point(10, 10)
            };
            button.Click += (s, e) =>
            {
                GenerateRandomFigures();
                Invalidate(); // обновление, все фигуры удаляются
            };

            Controls.Add(button);

        }

        private void GenerateRandomFigures()
        {
            figures.Clear();
            foreach (Label l in labels) {// удаление строк, лэйблов
                Controls.Remove(l);
                l.Dispose();
            }
            labels.Clear();
            for (int i = 0; i < 5; i++)
            {
                int type = rand.Next(5);
                int x = rand.Next(50, ClientSize.Width - 100);
                int y = rand.Next(50, ClientSize.Height - 100);

                switch (type)
                {
                    case 0:
                        double side = rand.NextDouble() * 50 + 20;
                        figures.Add(new Square(new PointF(x, y), side));
                        break;
                    case 1:
                        double width = rand.NextDouble() * 100 + 30;
                        double height = rand.NextDouble() * 100 + 30;
                        figures.Add(new RectangleFigure(new PointF(x, y), width, height));
                        break;
                    case 2:
                        double radius = rand.NextDouble() * 40 + 20;
                        figures.Add(new Circle(new PointF(x, y), radius));
                        break;
                    case 3:
                        double b = rand.NextDouble() * 80 + 30;
                        double h = rand.NextDouble() * 80 + 30;
                        figures.Add(new IsoscelesTriangle(new PointF(x, y), b, h));
                        break;
                    case 4:
                        double l = rand.NextDouble() * 80 + 30;
                        figures.Add(new EquilateralTriange(new PointF(x, y), l));
                        break;
                }
                Label label = new Label
                {
                    BackColor = Color.Transparent,
                    Text = figures[i].GetInfo(),
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);
                labels.Add(label);
                Console.WriteLine(figures[i].GetInfo());
            }
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var figure in figures)
            {
                figure.Draw(e.Graphics);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}