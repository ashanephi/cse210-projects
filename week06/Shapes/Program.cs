using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square box = new Square("Purple", 4);

        Rectangle rect = new Rectangle("Red", 6, 4);

        Circle c = new Circle("Yello", 7);


        shapes.Add(box);
        shapes.Add(rect);
        shapes.Add(c);

        foreach(Shape sh in shapes)
        {
            DisplayShapeInformation(sh);
            Console.WriteLine();
        }

    }
        public static void DisplayShapeInformation(Shape s)
        {
            Console.WriteLine($"The {s.GetColor()} shape has an area of {s.GetArea()}");
        }

}