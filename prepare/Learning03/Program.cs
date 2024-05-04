using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction defaultFract = new Fraction();
        Console.WriteLine(defaultFract.GetFractionString());
        Console.WriteLine(defaultFract.GetDecimalValue());

        Fraction topFract = new Fraction(9);
        Console.WriteLine(topFract.GetFractionString());
        Console.WriteLine(topFract.GetDecimalValue());

        Fraction bothFract = new Fraction(26, 5);
        Console.WriteLine(bothFract.GetFractionString());
        Console.WriteLine(bothFract.GetDecimalValue());
    }
}