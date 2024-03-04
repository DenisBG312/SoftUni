namespace Shapes;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    private double Height { get; set; }
    private double Width { get; set; }

    public override double CalculatePerimeter()
    {
        return 2 * Height + 2 * Width;
    }

    public override double CalculateArea()
    {
        return Height * Width;
    }

    public override string Draw()
    {
        return base.Draw() + $"{nameof(Rectangle)}";
    }
}