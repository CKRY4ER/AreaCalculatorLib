using AreaCalculatorLib.Exceptions;
using AreaCalculatorLib.Shapes;

namespace AreaCalculatorLib.Tests;

public class AreaCalculatorTests
{
    [Fact]
    public void CalculateCircleArea_Input4_50dot27()
    {
        var circle = new Circle(4);

        var area = circle.CalculateArea();

        Assert.Equal(50.27M, area);
    }

    [Fact]
    public void CalculateTriangleArea_Input3And4And5_6()
    {
        var triangle = new Triangle(3, 4, 5);

        var area = triangle.CalculateArea();

        Assert.Equal(6M, area);
    }

    [Fact]
    public void CreateImpossibleTriangle_Input10And4And5_ItsImpossible()
    {
        Assert.Throws<ImpossibleTriangleException>(() =>
        {
            var triangle = new Triangle(10, 4, 5);
        });
    }

    [Fact]
    public void CalculateAreaInCompileTime_Possible()
    {
        var circle = new Circle(4);
        var triangle = new Triangle(3, 4, 5);

        var circleArea = CalculateArea(circle);
        var triangleArea = CalculateArea(triangle);

        Assert.True(circleArea == 50.27M && triangleArea == 6M);
    }

    public decimal CalculateArea(IShape shape)
        => shape.CalculateArea();
}