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

    public void SaveToJsonFile(string filePath)
    {
        // Створюємо об'єкт JsonSerializerOptions 
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // Серіалізуємо об'єкт класу в JSON рядок
        string jsonString = JsonSerializer.Serialize(this, options);

        // Записуємо JSON рядок в файл
        File.WriteAllText(filePath, jsonString);
    }

    public static Fraction LoadFromJsonFile(string filePath)
    {
        // Зчитуємо JSON рядок з файлу
        string jsonString = File.ReadAllText(filePath);

        // Десеріалізуємо JSON рядок у об'єкт класу
        Fraction fraction = JsonSerializer.Deserialize<Fraction>(jsonString);

        return fraction;
    }
}
