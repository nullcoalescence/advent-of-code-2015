using advent_of_code_2015.Days;
using System.Numerics;

namespace advent_of_code_2015
{
    /*
     * Advent Of Code 2015
     * Args:
     *      integer representing day to run between 1 and 25
     *      or don't supply any args to be prompted for a day
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== Advent of Code 2015 ==");

            // Check for args (number representing which day to run). If no args, display interactive menu
            if (args.Length != 0)
            {
                var arg = args[0];             

                if (IsUserInputValid(arg))
                {                 
                    RunDay(int.Parse(arg));
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Unable to parse arg - running in interactive mode.");
                }
            }

            RunDay(PromptForDayAndValidate());
            Environment.Exit(1);
        }

        private static bool IsUserInputValid(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            if (int.TryParse(input, out int day))
            {
                if (day < 1 || day > 25)
                {
                    return false;
                }
            } 
            else
            {
                return false;
            }

            return true;
        }

        private static int PromptForDayAndValidate()
        {
            int day = 0;
            while (day == 0)
            {
                Console.WriteLine("Enter day to run (1 - 25): ");
                var response = Console.ReadLine();

                if (IsUserInputValid(response))
                {
                   day = int.Parse(response);
                }
                else
                {
                    Console.WriteLine("Invalid value.\nPlease enter a number 1 - 25.");
                }
            }

            return day;
        }

        // Add days to the switch in this method as I complete them.
        private static void RunDay(int day)
        {
            Console.WriteLine($"== Day {day} ==\n");

            switch (day)
            {
                case 1: new Day1().Run(); break;
                case 2: new Day2().Run(); break;
                case 3: new Day3().Run(); break;
                default: Console.WriteLine("Invalid day."); break;
            }
        }
    }
}