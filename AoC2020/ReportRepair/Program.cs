using System;
using System.Collections.Generic;
using System.IO;
using AocUtils;

namespace ReportRepair
{
    class Program
    {
        static HashSet<int> Nums = new HashSet<int>();
        static Dictionary<int, int> SumsToProducts = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();

            Console.ReadKey();
        }

        static void PartOne ()
        {
            Console.WriteLine("PartOne");
            Console.WriteLine("-------");

            Nums = new HashSet<int>();

            Utils.ReadInput(PartOneAction);
        }

        static void PartOneAction (string line)
        {
            try
            {
                int num = int.Parse(line);

                Nums.Add(num);
                if (Nums.Contains(2020 - num))
                {
                    Console.WriteLine("Found pair, {0} {1}", num, 2020 - num);
                    Console.WriteLine("Product: {0}", num * (2020 - num));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to process line:{0} | error:{1}", line, ex);
            }
        }
        static void PartTwo()
        {
            Console.WriteLine("");
            Console.WriteLine("PartTwo");
            Console.WriteLine("-------");

            Nums = new HashSet<int>();
            SumsToProducts = new Dictionary<int, int>();

            Utils.ReadInput(PartTwoAction);
        }

        static void PartTwoAction (string line)
        {
            try
            {
                int num = int.Parse(line);

                if (SumsToProducts.ContainsKey(2020 - num))
                {
                    Console.WriteLine("Found trio");
                    Console.WriteLine("Product: {0}", SumsToProducts[2020 - num] * num);
                }

                foreach (int num2 in Nums)
                {
                    SumsToProducts[num + num2] = num * num2;
                }

                Nums.Add(num);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to process line:{0} | error:{1}", line, ex);
            }
        }
    }
}
