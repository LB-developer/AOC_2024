using System.Text.RegularExpressions;

namespace AOC.Day3;

public class ProblemTwo
{
    public static int total = 0;

    public int Solution()
    {

        using (StreamReader reader = new StreamReader("Day3/input.txt"))
        {
            string? line;

            while ((line = reader.ReadLine()) != null)
            {

                var removed = RemoveInvalidMulFromLine(line);
                var muls = extractMul(removed);
                var nums = extractNums(muls);
                foreach (var (numOne, numTwo) in nums)
                {
                    total += mulNums(numOne, numTwo);
                }

            }
        }

        return total;

    }


    // good
    internal string RemoveInvalidMulFromLine(string line)
    {
        line += "do()";
        string extractValidBoundary = @"don't\(\).*?do\(\)";
        line = Regex.Replace(line, extractValidBoundary, "");
        return line;
    }

    // good
    internal MatchCollection extractMul(string line)
    {

        string extractValidArguments = @"mul\(\d+,\d+\)";

        Regex argumentsRG = new Regex(extractValidArguments);

        MatchCollection argumentsMatch = argumentsRG.Matches(line);

        return argumentsMatch;

    }
    internal List<Tuple<int, int>> extractNums(MatchCollection matches)
    {
        var numbersToMultiply = new List<Tuple<int, int>>();

        foreach (var match in matches)
        {
            string? strMatch = match.ToString();
            string takeNumbersPattern = @"(\d+),\s?(\d+)";
            Regex takeNumbersRegex = new Regex(takeNumbersPattern);

            if (strMatch == null)
            {
                throw new FormatException("Couldn't convert matches to a string");
            }

            Match numbers = takeNumbersRegex.Match(strMatch);
            string numOneString = numbers.Groups[1].Value;
            string numTwoString = numbers.Groups[2].Value;

            int numOne;
            if (int.TryParse(numOneString, out int numberOne))
            {
                numOne = numberOne;
            }
            else
            {
                throw new FormatException("Couldn't convert first number as a string to number");
            }

            int numTwo;
            if (int.TryParse(numTwoString, out int numberTwo))
            {
                numTwo = numberTwo;
            }
            else
            {
                throw new FormatException("Couldn't convert second number as a string to number");
            }

            numbersToMultiply.Add(Tuple.Create(numOne, numTwo));
        }
        return numbersToMultiply;
    }

    internal int mulNums(int numOne, int numTwo)
    {
        Console.WriteLine($"Multiplying {numOne} x {numTwo}");
        return numOne * numTwo;
    }
}


