

using System.Text.RegularExpressions;

namespace AOC.Day3;

public class ProblemOne
{
    public static int Solution()
    {

        int total = 0;

        using (StreamReader reader = new StreamReader("Day3/input.txt"))
        {
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                string pattern = @"mul\(\d+,\d+\)";
                Regex rg = new Regex(pattern);

                MatchCollection matched = rg.Matches(line);

                foreach (var match in matched)
                {
                    string? curr = match.ToString();
                    string takeNumbersPattern = @"(\d+),\s?(\d+)";
                    Regex takeNumbersRegex = new Regex(takeNumbersPattern);
                    if (curr != null)
                    {
                        Match numbers = takeNumbersRegex.Match(curr);
                        string numOneString = numbers.Groups[1].Value;
                        string numTwoString = numbers.Groups[2].Value;

                        int numOne;
                        if (int.TryParse(numOneString, out int numberOne))
                        {
                            numOne = numberOne;
                        }
                        else
                        {
                            throw new FormatException("Couln't convert first number as a string to number");
                        }

                        int numTwo;
                        if (int.TryParse(numTwoString, out int numberTwo))
                        {
                            numTwo = numberTwo;
                        }
                        else
                        {
                            throw new FormatException("Couln't convert second number as a string to number");
                        }

                        total += numOne * numTwo;
                    }
                }
            }
        }

        return total;

    }
}
