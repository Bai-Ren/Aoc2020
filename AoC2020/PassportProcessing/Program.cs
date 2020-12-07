using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AocUtils;

namespace PassportProcessing
{
    class Program
    {
        const bool Verbose = false;

        static Dictionary<string, string> Fields = new Dictionary<string, string>();
        static readonly Regex R = new Regex(@"(\w{3}):([\w#]+)");
        static int PartOne = 0;
        static int PartTwo = 0;

        static readonly Regex YearRegex = new Regex(@"^\d{4}$");
        static readonly Regex HgtRegex = new Regex(@"^(\d+)(cm|in)$");
        static readonly Regex HclRegex = new Regex(@"^#[\da-f]{6}$");
        static readonly string[] EclColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        static readonly Regex PidRegex = new Regex(@"^\d{9}$");

        static readonly string[] RequiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        static void Main(string[] args)
        {
            Utils.ForEachLine(Action);

            if (Fields.Count != 0)
            {
                CheckValid();
            }

            Console.WriteLine("PartOne");
            Console.WriteLine("-------");
            Console.WriteLine("Valid Passports: {0}", PartOne);
            Console.WriteLine("");
            Console.WriteLine("PartTwo");
            Console.WriteLine("-------");
            Console.WriteLine("Valid Passports: {0}", PartTwo);

            Console.ReadKey();
        }

        static void Action(string line)
        {
            if (line.Length == 0)
            {
                CheckValid();
                return;
            }

            foreach (Match match in R.Matches(line))
            {
                Fields[match.Groups[1].Value] = match.Groups[2].Value;
            }
        }

        static void CheckValid()
        {
            if (RequiredFields.All(field => Fields.ContainsKey(field)))
            {
                PartOne++;

                if (ValidYear(Fields["byr"], 1920, 2002) &&
                    ValidYear(Fields["iyr"], 2010, 2020) &&
                    ValidYear(Fields["eyr"], 2020, 2030) &&
                    ValidHeight(Fields["hgt"]) &&
                    ValidHairColor(Fields["hcl"]) &&
                    ValidEyeColor(Fields["ecl"]) &&
                    ValidPassportId(Fields["pid"]))
                {
                    PartTwo++;
                    LogVerbose("valid");
                }
                else
                {
                    LogVerbose("invalid");
                }

                LogVerbose("");
            }

            Fields = new Dictionary<string, string>();
        }

        static bool ValidYear (string field, int lowerBound, int upperBound)
        {
            Match match = YearRegex.Match(field);

            if (!match.Success)
            {
                LogVerbose("Year Bad: {0} <= {1} <= {2}", lowerBound, field, upperBound);
                return false;
            }

            int year = int.Parse(field);

            if (year < lowerBound || year > upperBound)
            {
                LogVerbose("Year Bad: {0} <= {1} <= {2}", lowerBound, field, upperBound);
                return false;
            }

            LogVerbose("Year Ok!: {0} <= {1} <= {2}", lowerBound, field, upperBound);
            return true;
        }
        static bool ValidHeight (string field)
        {
            Match match = HgtRegex.Match(field);

            if (!match.Success)
            {
                LogVerbose("Hgt Bad: {0}", field);
                return false;
            }

            if (match.Groups[2].Value == "in")
            {
                int height = int.Parse(match.Groups[1].Value);

                if (height < 59 || height > 76)
                {
                    LogVerbose("Hgt Bad: in {0} <= {1} <= {2}", 59, field, 76);
                    return false;
                }
                LogVerbose("Hgt Ok!: in {0} <= {1} <= {2}", 59, field, 76);
            }
            else
            {
                int height = int.Parse(match.Groups[1].Value);

                if (height < 150 || height > 193)
                {
                    LogVerbose("Hgt Bad: cm {0} <= {1} <= {2}", 150, field, 193);
                    return false;
                }
                LogVerbose("Hgt Ok!: cm {0} <= {1} <= {2}", 150, field, 193);
            }

            return true;
        }
        static bool ValidHairColor (string field)
        {
            Match match = HclRegex.Match(field);

            if (!match.Success)
            {
                LogVerbose("Hcl Bad: {0}", field);
                return false;
            }

            LogVerbose("Hcl Ok!: {0}", field);
            return true;
        }
        static bool ValidEyeColor (string field)
        {
            if (EclColors.Any(color => field.Equals(color)))
            {
                LogVerbose("Ecl Ok!: {0}", field);
                return true;
            }

            LogVerbose("Ecl Bad: {0}", field);
            return false;
        }
        static bool ValidPassportId(string field)
        {
            Match match = PidRegex.Match(field);

            if (!match.Success)
            {
                LogVerbose("Pid Bad: {0}", field);
                return false;
            }

            LogVerbose("Pid Ok!: {0}", field);

            return true;
        }

        static void LogVerbose(string format, params object[] args)
        {
            if (Verbose)
            {
                Console.WriteLine(format, args);
            }
        }
    }
}
