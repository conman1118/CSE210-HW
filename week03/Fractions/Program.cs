using System;
using MyFractions;

class Program
{
    static void Main(string[] args)
    {

        //basically this calls the f1 function and makes it write down the
        //fraction and the deciaml value if there is one. 
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());


        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());


        Fraction f3 = new Fraction(3, 4);    
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());


        Fraction f4 = new Fraction(1, 3);    
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());



        // Test setters & getters
        f1.Top = 5;
        f1.Bottom = 3;
        Console.WriteLine(f1.Top);
        Console.WriteLine(f1.Bottom);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
    }
}
