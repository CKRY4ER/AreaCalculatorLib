using AreaCalculatorLib.Exceptions;

namespace AreaCalculatorLib.Shapes;

public sealed class Circle : IShape
{
    public Circle(double radius)
        => _radius = radius > 0 ? radius : throw new NonCorrectValueException();

    private double _radius;

    public double Radius { get => _radius; }

    public decimal CalculateArea(uint round = 2)
    {
        double area = Math.Pow(Radius, 2) * Math.PI;

        return Math.Round((decimal)area, (int)round);
    }
}
