using System;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        //fun fact! This is how far I remember the didgits of pi
        return _radius * _radius * 3.1415926535897932384;
    }
}