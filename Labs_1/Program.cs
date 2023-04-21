

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

Fraction f_json = new Fraction(1, 2);
f_json.SaveToFile("fraction.json");

Fraction loadedFraction = Fraction.LoadFromFile("fraction.json");
