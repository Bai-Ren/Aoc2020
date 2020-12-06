using System;
using System.Collections.Generic;
using System.IO;

namespace AocUtils
{
    public class Utils
    {
        public static void ReadInput(Action<string> action)
        {
            IEnumerable<string> lines = File.ReadAllLines("input.txt");

            foreach (string line in lines)
            {
                action.Invoke(line);
            }
        }
    }
}
