using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AocUtils;

namespace TobogganTrajectory
{
    class Program
    {
        static string[] Grid = null;
        static void Main(string[] args)
        {
            Grid = Utils.GetLines();

            int product = 1;
            int partOne = CheckSlope(3, 1);
            product *= partOne;
            product *= CheckSlope(1, 1);
            product *= CheckSlope(5, 1);
            product *= CheckSlope(7, 1);
            product *= CheckSlope(1, 2);

            Console.WriteLine("PartOne");
            Console.WriteLine("-------");
            Console.WriteLine("Encountered {0} trees", partOne);
            Console.WriteLine("");
            Console.WriteLine("PartTwo");
            Console.WriteLine("-------");
            Console.WriteLine("Product {0}", product);

            Console.ReadKey();
        }

        static int CheckSlope (int right, int down)
        {
            int i = 0;
            int j = 0;
            int trees = 0;
            while (i < Grid.Length)
            {
                if (Grid[i][j] == '#')
                {
                    trees++;
                }

                i += down;
                j += right;

                if (j >= Grid[0].Length)
                {
                    j -= Grid[0].Length;
                }
            }

            return trees;
        }
    }
}
