using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your grade percentage? ");
        string userInput = Console.ReadLine();
        int percent = int.Parse(userInput);

        string letter = "";


        if (percent >= 90)
        {
            letter = "A";
        }

        else if (percent >= 80)
        {
            letter = "B";
        }

        else if (percent >= 70)
        {
            letter = "C";
        }

        else if (percent >= 60)
        {
            letter = "D";
        }

        else 
        {
            letter = "F";
        }


        Console.WriteLine($" Your Grade is: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("You Passed!");
        }

        else
        {
            Console.WriteLine("Better luck next time!");
        }

    }
}