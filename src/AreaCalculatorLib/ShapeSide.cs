using AreaCalculatorLib.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace AreaCalculatorLib;

public struct ShapeSide
{
    public ShapeSide(double lenght)
        => _lenght = lenght > 0 ? lenght : throw new NonCorrectValueException();

    private double _lenght;

    public double Lenght { get => _lenght; }

    public static bool operator ==(ShapeSide sideOne, ShapeSide sideTwo) 
        => sideOne.Equals(sideTwo);

    public static bool operator !=(ShapeSide sideOne, ShapeSide sideTwo)
        => !(sideOne == sideTwo);
}
