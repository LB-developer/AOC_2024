
namespace AOC.Day2;

public class ProblemOne
{
    public static int Solution()
    {
        int safeCount = 0;

        FileStream fileStream = new FileStream("Day2/input.txt", FileMode.Open);
        using (StreamReader reader = new StreamReader(fileStream))
        {
            int[]? line;
            // split each element of the line and cast to int
            while ((line = reader
                        .ReadLine()?
                        .Split(" ")
                        .Select(strEl =>
                            {
                                if (int.TryParse(strEl, out int number))
                                {
                                    return number;
                                }
                                else
                                {
                                    throw new FormatException("Couldn't convert line element to number");
                                }
                            })
                        .ToArray()
                        ) != null)
            {
                if (SafetyCheck(line))
                {
                    ++safeCount;
                }
            }
            fileStream.Close();

            return safeCount;
        }

    }

    public static bool SafetyCheck(int[] line)
    {
        // calculate if the current line is safe
        var length = line.Length;
        if (MinMaxConditionCheck(line, length))
        {
            bool isIncreasing = (line[0] < line[1]);
            // loop over each line
            for (int i = 0, j = 1; i < length - 1; ++i, ++j)
            {
                var currNum = line[i];
                var nextNum = line[j];
                var difference = Math.Abs(currNum - nextNum);

                // all numbers must have an absolute difference of 1-3
                if (!(DistanceConditionCheck(currNum, nextNum)))
                {
                    return false;
                }

                // check next number against current
                if (isIncreasing)
                {

                    // number must always be increasing
                    if (currNum > nextNum)
                    {
                        return false;
                    }
                }
                else
                {
                    // number must always be decreasing
                    if (currNum < nextNum)
                    {
                        return false;
                    }
                }

            }

            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool DistanceConditionCheck(int currNum, int nextNum)
    {
        var difference = Math.Abs(currNum - nextNum);
        if (
                difference > 3
                || difference < 1
            )
        {
            return false;
        }

        return true;
    }

    public static bool MinMaxConditionCheck(int[] line, int listLength)
    {

        var firstNum = line[0];
        var lastNum = line[listLength - 1];

        // check if last number meets the min/max conditions i.e.
        // if the length is 5 then the last number cant be +-15 (next item must differ by max of 3)
        if (
                lastNum > firstNum + ((listLength - 1) * 3)
                || lastNum < firstNum - ((listLength - 1) * 3)
            )
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}


