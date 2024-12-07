using System.Text.RegularExpressions;

namespace AOC.Day3;

public class ProblemTwo
{
    public static int total = 0;

    public static int Solution()
    {
        // 98632444 -- Too High
        // 8_______ -- Too High
        // 5_______ -- Too Low


        using (StreamReader reader = new StreamReader("Day3/input.txt"))
        {
            string? line;

            while ((line = reader.ReadLine()) != null)
            {

                RemoveInvalidMulFromLine(line);
                var muls = extractMul(line);
                var (numOne, numTwo) = extractNums(muls);
                total += mulNums(numOne, numTwo);

            }
        }

        return total;

    }


    public static void RemoveInvalidMulFromLine(string line)
    {
        string extractValidBoundary = @"don't\(\).*?do\(\)";
        line = Regex.Replace(line, extractValidBoundary, "");
    }

    public static MatchCollection extractMul(string line)
    {
        string extractValidArguments = @"mul\(\d+,\d+\)";

        Regex argumentsRG = new Regex(extractValidArguments);

        MatchCollection argumentsMatch = argumentsRG.Matches(line);

        return argumentsMatch;

    }
    public static Tuple<int, int> extractNums(MatchCollection matches)
    {

        string? curr = matches.ToString();
        string takeNumbersPattern = @"(\d+),\s?(\d+)";
        Regex takeNumbersRegex = new Regex(takeNumbersPattern);

        if (curr == null)
        {
            throw new FormatException("Couldn't convert matches to a string");
        }

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

        return Tuple.Create(numOne, numTwo);
    }

    public static int mulNums(int numOne, int numTwo)
    {
        return numOne * numTwo;
    }
}


