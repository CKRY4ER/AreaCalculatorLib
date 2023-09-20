using AreaCalculatorLib.Exceptions;

namespace AreaCalculatorLib.Shapes;

public sealed class Triangle : IShape
{
    public Triangle(double abSide, double cbSide, double acSide)
    {
        if ((abSide + cbSide <= acSide) || (cbSide + acSide <= abSide) || (abSide + acSide <= cbSide))
            throw new ImpossibleTriangleException();

        _abSide = new(abSide);
        _cbSide = new(cbSide);
        _acSide = new(acSide);
    }

    private ShapeSide _abSide;
    private ShapeSide _cbSide;
    private ShapeSide _acSide;

    public decimal CalculateArea(uint round = 2)
    {
        double halfPerimeter = (_abSide.Lenght + _cbSide.Lenght + _acSide.Lenght) / 2;

        var area = Math.Sqrt(halfPerimeter * (halfPerimeter - _abSide.Lenght) * (halfPerimeter - _cbSide.Lenght) * (halfPerimeter - _acSide.Lenght));

        return Math.Round((decimal)area, (int)round);
    }

    public bool IsRectangularTriangle()
    {
        var sideArray = new double[] { _abSide.Lenght, _cbSide.Lenght, _acSide.Lenght };

        sideArray = sideArray.OrderByDescending(sideLenght => sideLenght).ToArray();

        return Math.Pow(sideArray[0], 2) == Math.Pow(sideArray[1], 2) + Math.Pow(sideArray[2], 2);
    }
}
