using System.IO;
using System.Text.Json;

class Fraction
{
    private int numerator;   
    private int denominator; 

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    public void Add(Fraction other)
    {
        int lcm = LCM(this.denominator, other.denominator);
        int newNumerator = lcm / this.denominator * this.numerator + lcm / other.denominator * other.numerator;
        this.numerator = newNumerator;
        this.denominator = lcm;
    }

    public void Multiply(double multiplier)
    {
        this.numerator = (int)Math.Round(this.numerator * multiplier);
    }

  
    public void Divide(double divisor)
    {
        this.denominator = (int)Math.Round(this.denominator * divisor);
    }

    
    public int LCM(int a, int b)
    {
        return a * b / GCD(a, b);
    }

   
    public int GCD(int a, int b)
    {
        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }

    public void SaveToFile(string fileName)
    {
        string jsonString = JsonSerializer.Serialize(this);
        File.WriteAllText(fileName, jsonString);
    }

    public static Fraction LoadFromFile(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<Fraction>(jsonString);
    }
}
