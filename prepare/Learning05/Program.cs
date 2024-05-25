using System;
public abstract class Shape
{
    private string _color;

    public Shape(string shapeColor)
    {
        _color = shapeColor;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string shapeColor)
    {
        _color = shapeColor;
    }
    public abstract double GetArea();
}
public class Square : Shape
{
    private double _side;

    public Square(string shapeColor, double side) : base (shapeColor)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return _side * _side;
    }
}
public class Rectangle : Shape
{
    private double _length;
    private double _width;

    public Rectangle(string shapeColor, double length, double width) : base (shapeColor)
    {
        _length = length;
        _width = width;
    }
    public override double GetArea()
    {
        return _length * _width;
    }
}
public class Circle : Shape
{
    private double _radius;

    public Circle(string shapeColor, double radius) : base (shapeColor)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square shape1 = new Square("Yellow", 34);
        shapes.Add(shape1);

        Rectangle shape2 = new Rectangle("Green", 12, 8);
        shapes.Add(shape2);

        Circle shape3 = new Circle("Purple", 784);
        shapes.Add(shape3);

        foreach (Shape shape in shapes)
        {
            string shapeColor = shape.GetColor();

            double shapeArea = shape.GetArea();

            Console.WriteLine($"The {shapeColor} shape's area is {shapeArea} square inches.");
        }
    }
}