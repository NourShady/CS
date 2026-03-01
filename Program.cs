
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Shape Calculator ===");
        Console.WriteLine("1. Rectangle");
        Console.WriteLine("2. Circle");
        Console.WriteLine("3. Triangle");

        Console.Write("Choose shape: ");
        int choice = int.Parse(Console.ReadLine());

        Shape shape = null;

        switch (choice)
        {
            case 1:
                Console.Write("Width: ");
                double w = double.Parse(Console.ReadLine());

                Console.Write("Height: ");
                double h = double.Parse(Console.ReadLine());

                shape = new Rectangle(w, h);
                break;

            case 2:
                Console.Write("Radius: ");
                double r = double.Parse(Console.ReadLine());

                shape = new Circle(r);
                break;

            case 3:
                Console.Write("Side A: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Side B: ");
                double b = double.Parse(Console.ReadLine());

                Console.Write("Side C: ");
                double c = double.Parse(Console.ReadLine());

                shape = new Triangle(a, b, c);
                break;
        }

        Console.WriteLine();
        shape?.Display();

        Console.ReadKey();
    }
}

abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();

    public virtual void Display()
    {
        Console.WriteLine($"Area = {GetArea():F2}");
        Console.WriteLine($"Perimeter = {GetPerimeter():F2}");
    }
}
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
}
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override double GetArea()
    {
        // Heron's formula
        double s = (A + B + C) / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    public override double GetPerimeter()
    {
        return A + B + C;
    }
}
