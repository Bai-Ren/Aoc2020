using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AocUtils;

namespace PasswordPhilosophy
{
    public class Program
    {
        static int PartOneValid = 0;
        static int PartTwoValid = 0;
        static string Pattern = @"(\d+)-(\d+) (\w): (.*)";
        static Regex R = new Regex(Pattern);

        static void Main(string[] args)
        {
            Utils.ForEachLine(Action);

            Console.WriteLine("PartOne");
            Console.WriteLine("-------");
            Console.WriteLine("Valid passwords: {0}", PartOneValid);
            Console.WriteLine("");
            Console.WriteLine("PartTwo");
            Console.WriteLine("-------");
            Console.WriteLine("Valid passwords: {0}", PartTwoValid);

            Console.ReadKey();
        }

        static void PartOne()
        {
            Console.WriteLine("PartOne");
            Console.WriteLine("-------");

            Utils.ForEachLine(Action);

            Console.WriteLine("Valid passwords: {0}", PartOneValid);
        }

        static void Action(string line)
        {
            Match match = R.Match(line);
            if (!match.Success)
            {
                Console.WriteLine("Error processing line:{0}", line);
                return;
            }

            int lowerBound = int.Parse(match.Groups[1].Value);
            int upperBound = int.Parse(match.Groups[2].Value);
            char letter = match.Groups[3].Value[0];
            string password = match.Groups[4].Value;

            int letterCount = 0;

            foreach (char c in password)
            {
                if (c == letter)
                {
                    letterCount++;
                }
            }

            if (lowerBound <= letterCount && letterCount <= upperBound)
            {
                PartOneValid++;
            }

            if ((password[lowerBound - 1] == letter && password[upperBound - 1] != letter) ||
                (password[lowerBound - 1] != letter && password[upperBound - 1] == letter))
            {
                PartTwoValid++;
            }
                
        }
    }
}
