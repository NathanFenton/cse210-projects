using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square shape1 = new Square("red", 1);
        shapes.Add(shape1);

        Rectangle shape2 = new Rectangle("white", 7, 7);
        shapes.Add(shape2);

        Circle shape3 = new Circle("blue", 6);
        shapes.Add(shape3);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"The {color} shape's area is {area}");
        }
    }
}