using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 3);

        Rectangle rectangle = new Rectangle("Blue", 4, 5);

        Circle circle = new Circle("Green", 6);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        Console.WriteLine("\nAll Shapes in the List:\n");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}