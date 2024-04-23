using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowsAndBulls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n   _____                                    _   _           _ _     \r\n  / ____|                                  | | | |         | | |    \r\n | |     _____      _____    __ _ _ __   __| | | |__  _   _| | |___ \r\n | |    / _ \\ \\ /\\ / / __|  / _` | '_ \\ / _` | | '_ \\| | | | | / __|\r\n | |___| (_) \\ V  V /\\__ \\ | (_| | | | | (_| | | |_) | |_| | | \\__ \\\r\n  \\_____\\___/ \\_/\\_/ |___/  \\__,_|_| |_|\\__,_| |_.__/ \\__,_|_|_|___/\r\n                                                                    \r\n                                                                    \r\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter any key to continue");
            if (Console.ReadLine() != "hello id like some water")
            {
                Random r = new Random();
                int[] correctNum = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    correctNum[i] = r.Next(1, 10);
                    for (int j = 0; j < i; j++)
                    {
                        if (i == 0)
                        {
                            while (correctNum[i] == correctNum[j])
                            {
                                correctNum[i] = r.Next(1, 10);
                                j = 0;
                            }
                        }
                        else
                        {
                            while (correctNum[i] == correctNum[j])
                            {
                                correctNum[i] = r.Next(0, 10);
                                j = 0;
                            }
                        }
                    }
                }
                int[] userNum = new int[4];
                int guesses = 1;
                while (userNum != correctNum)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        bool validNumber = false;
                        while (!validNumber)
                        {
                            Console.WriteLine("Enter number " + (i + 1));
                            string input = Console.ReadLine();
                            if (input[0] != '0')
                            {
                                int number = Convert.ToInt32(input);
                                bool isUnique = true;
                                for (int j = 0; j < i; j++)
                                {
                                    if (userNum[j] == number)
                                    {
                                        isUnique = false;
                                        Console.WriteLine("This number has already been entered. Please enter a unique number.");
                                    }
                                }
                                if (isUnique)
                                {
                                    userNum[i] = number;
                                    validNumber = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a number that does not start with 0.");
                            }
                        }
                    }
                    int cows = 0;
                    int bulls = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (userNum[i] == correctNum[i])
                        {
                            bulls = bulls + 1;
                        }
                        else if (userNum[i] == correctNum[0] || userNum[i] == correctNum[1] || userNum[i] == correctNum[2] || userNum[i] == correctNum[3])
                        {
                            cows = cows + 1;
                        }
                    }
                    Console.WriteLine("bulls: " + bulls);
                    Console.WriteLine("cows: " + cows);
                    guesses = guesses + 1;
                }
                Console.WriteLine("You won with " + guesses + " guesses!");
            }
        }
    }
}