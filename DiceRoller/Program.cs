using System;

namespace Dice Roller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //intro message
            Console.WriteLine("Welcome to the Grnad Circus Casino!");
            Console.WriteLine();
            //receiving user input
            Console.Write("How many sides should each die have? ");
            //initializing variables
            bool runProgram = true;
            int diceSides;            
            while(!Int32.TryParse(Console.ReadLine(), out diceSides))
            {
                Console.Clear();
                Console.WriteLine("Sorry, that was an invalid input, please try again.");
                Console.WriteLine();                
                Console.Write("How many sides should each die have? ");
            }
            Console.WriteLine();
            int rollAmount = 0;
            while (runProgram)
            {
                rollAmount++;
                int roll1 = (GenerateRandom(diceSides));
                int roll2 = (GenerateRandom(diceSides));                
                int rollTotal = roll1 + roll2;
                //displaying output
                Console.WriteLine();
                Console.WriteLine($"Roll {rollAmount}");                
                Console.WriteLine($"You have rolled a {roll1} and a {roll2} ({rollTotal} total)");
                Console.WriteLine(ReturnOutputMessage(roll1, roll2));
                while (true)
                {
                    Console.WriteLine();
                    Console.Write("Would you like to roll again? (y/n): ");
                    string loopCheck = Console.ReadLine();
                    if (loopCheck.ToLower().Trim() == "y")
                    {
                        runProgram = true;
                        break;
                    }
                    else if (loopCheck.ToLower().Trim() == "n")
                    {
                        runProgram = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that was an invalid input, please try again.");
                        Console.WriteLine();
                    }
                }
            }
        }

        static int GenerateRandom(int value)
        {
            Random rnd = new Random();
            int num = rnd.Next(value);
            return num + 1;
        }
        static string ReturnOutputMessage(int value1, int value2)
        {
            int total = value1 + value2;
            string outputMessage = "";
            if (value1 == 1 && value2 == 1)
            {
                outputMessage = "Snake Eyes";
            }
            else if ((value1 == 1 && value2 == 2) || (value1 == 2 && value2 == 1))
            {
                outputMessage = "Ace Dueces";
            }
            else if (value1 == 6 && value2 == 6)
            {
                outputMessage = "Box Cars";
            }
            else
            {
                Console.WriteLine();
            }
            if (total == 7 || total == 11)
            {
                Console.WriteLine("Win!");
            }
            else if (total == 2 || total == 3 || total == 12)
            {
                Console.WriteLine("Craps!");
            }
            return outputMessage;
        }

    }
}