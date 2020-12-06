using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportRepair
{
    class Program
    {
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

            IEnumerable<string> lines = File.ReadAllLines("input.txt");

            HashSet<int> nums = new HashSet<int>();

            foreach (string line in lines)
            {
                try
                {
                    int num = int.Parse(line);

                    nums.Add(num);
                    if (nums.Contains(2020 - num))
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
        }
        static void PartTwo()
        {
            Console.WriteLine("PartTwo");
            Console.WriteLine("-------");

            IEnumerable<string> lines = File.ReadAllLines("input.txt");

            HashSet<int> nums = new HashSet<int>();
            Dictionary<int, int> sumsToProducts = new Dictionary<int, int>();

            foreach (string line in lines)
            {
                try
                {
                    int num = int.Parse(line);

                    if (sumsToProducts.ContainsKey(2020 - num))
                    {
                        Console.WriteLine("Found trio");
                        Console.WriteLine("Product: {0}", sumsToProducts[2020 - num] * num);
                        break;
                    }

                    foreach(int num2 in nums)
                    {
                        sumsToProducts[num + num2] = num * num2;
                    }

                    nums.Add(num);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to process line:{0} | error:{1}", line, ex);
                }
            }
        }
    }
}
