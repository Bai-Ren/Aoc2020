using System;
using System.Collections.Generic;
using System.IO;

namespace AocUtils
{
    public class Utils
    {
        private const string FileName = "input.txt";
        public static void ForEachLine(Action<string> action)
        {
            IEnumerable<string> lines = File.ReadAllLines(FileName);

            foreach (string line in lines)
            {
                action.Invoke(line);
            }
        }

        public static string[] GetLines()
        {
            return File.ReadAllLines(FileName);
        }
    }
}
