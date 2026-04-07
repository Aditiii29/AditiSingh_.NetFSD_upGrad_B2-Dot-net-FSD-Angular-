using System;

namespace Day_2
{
    class Shape
    {
        public virtual double CalculateArea()
        {
            return 0;
        }
    }

    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override double CalculateArea()
        {
            return Length * Width;
        }
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Problem3
    {
        static void Main(string[] args)
        {
            Shape shape1 = new Rectangle { Length = 5, Width = 4 };
            Console.WriteLine("Rectangle Area: " + shape1.CalculateArea());

            Shape shape2 = new Circle { Radius = 3 };
            Console.WriteLine("Circle Area: " + shape2.CalculateArea());
        }
    }
}