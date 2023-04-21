

Fraction f = new Fraction(1, 2);
Console.WriteLine(f);
f.ToString();

Fraction g = new Fraction(1, 3);
f.Add(g);
Console.WriteLine(f);      

f.Multiply(1.5);
Console.WriteLine(f);         

f.Divide(2);
Console.WriteLine(f);   

Fraction h = new Fraction(1,2);
Console.WriteLine(h.LCM(8, 128));

Console.WriteLine(h.GCD(8, 16));

f.SaveToJsonFile("fraction.json");

// Завантажуємо об'єкт класу з JSON файлу
Fraction loadedFraction = Fraction.LoadFromJsonFile("fraction.json");

// Використовуємо методи класу з завантаженого об'єкту
loadedFraction.Add(new Fraction(1, 2));
Console.WriteLine(loadedFraction.ToString());