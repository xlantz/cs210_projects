using System;

public class Fraction
{
    private int fracTop;

    private int fracBot;

    public Fraction()
    {
        fracTop = 1;

        fracBot = 1;
    }

    public Fraction(int number)
    {
        fracTop = number;

        fracBot = 1;
    }

    public Fraction(int top, int bot)
    {
        fracTop = top;

        fracBot = bot;
    }

        public string GetFractionString()
    {
        string fractOut = $"{fracTop}/{fracBot}";

        return fractOut;
    }

    public double GetDecimalValue()
    {
        double decVal = (double)fracTop / (double)fracBot;

        return decVal;
    }

}