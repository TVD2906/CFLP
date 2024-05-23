//Definește o structură Point cu două câmpuri X și Y.
//Definește o clasă Rectangle cu două câmpuri Width și Height.
//Creează metode care modifică valorile structurilor și claselor, transmise fie prin valoare, fie prin referință.
//Demonstrează utilizarea modificatorului in pentru a transmite parametri prin referință, fără a permite modificarea lor.

using System;

struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point p1 = new Point(10, 20);
        Console.WriteLine($"Point initial: ({p1.X}, {p1.Y})");

        ModifyPointByValue(p1);
        Console.WriteLine($"Dupa ModifyPointByValue: ({p1.X}, {p1.Y})");

        ModifyPointByRef(ref p1);
        Console.WriteLine($"Dupa ModifyPointByRef: ({p1.X}, {p1.Y})");

        Rectangle rect = new Rectangle(30, 40);
        Console.WriteLine($"Rectangle initial: {rect.Width} x {rect.Height}");

        ModifyRectangleByValue(rect);
        Console.WriteLine($"Dupa ModifyRectangleByValue: {rect.Width} x {rect.Height}");

        ModifyRectangleByRef(ref rect);
        Console.WriteLine($"Dupa ModifyRectangleByRef: {rect.Width} x {rect.Height}");

        int readonlyArgument = 44;
        InArgExample(readonlyArgument);
        Console.WriteLine($"readonlyArgument dupa InArgExample: {readonlyArgument}");
    }

    static void ModifyPointByValue(Point point)
    {
        point.X += 10;
        point.Y += 10;
    }

    static void ModifyPointByRef(ref Point point)
    {
        point.X += 10;
        point.Y += 10;
    }

    static void ModifyRectangleByValue(Rectangle rect)
    {
        rect.Width += 10;
        rect.Height += 10;
    }

    static void ModifyRectangleByRef(ref Rectangle rect)
    {
        rect = new Rectangle(rect.Width + 10, rect.Height + 10);
    }

    static void InArgExample(in int number)
    {
        Console.WriteLine($"Parametru 'in': {number}");
    }
}
