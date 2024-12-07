
namespace AOC.Day2;

// TODO: Finish Solving
public class ProblemTwo
{

    // public static int LineNum = 0;

    public static int Solution()
    {

        int safeCount = 0;

        FileStream fileStream = new FileStream("Day2/input.txt", FileMode.Open);
        using (StreamReader reader = new StreamReader(fileStream))
        {
            List<int>? line;
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
                                    throw new FormatException();
                                }
                            })
                        .ToList()
                        ) != null)
            {
                // ++LineNum;

                (List<int> inputline, int tolerance, int curr, int next, bool isIncreasing, int validSize) = InputCalculator(line);
                if (SafetyCheck(line, tolerance, curr, next, isIncreasing, validSize))
                {
                    ++safeCount;
                }
                else
                {
                }
            }
            fileStream.Close();

            return safeCount;
        }
    }


    public static Tuple<List<int>, int, int, int, bool, int> InputCalculator(List<int> line)
    {

        var curr = 0;
        var next = 1;

        var tolerance = 0;
        bool isIncreasing;

        while (line[0] == line[1] && tolerance < 2)
        {
            line.RemoveAt(0);
            ++tolerance;
        }

        isIncreasing = line[0] < line[1];
        var validSize = line.Count - 1 - tolerance;

        return Tuple.Create(line, tolerance, curr, next, isIncreasing, validSize);

    }

    public static bool SafetyCheck(List<int> line, int tolerance, int curr, int next, bool isIncreasing, int validSize)
    {

        if (tolerance > 1 || line.Count < validSize)
        {
            return false;
        }
        else if (next == line.Count)
        {
            return true;
        }

        var currNum = line[curr];
        var nextNum = line[next];

        // TODO: Move shared checks into separate class
        if (!(AOC.Day2.ProblemOne.DistanceConditionCheck(currNum, nextNum)))
        {
            ++tolerance;
            if (tolerance > 1)
            {
                return false;
            }
            // copy line to add and remove easily
            var originalLine = new List<int>(line);

            // try solve by removing the next number
            if (!(RemovalCheck(line, tolerance, curr, curr, next, validSize)))
            {
                // removing the next number didn't work so try solving by removing the current number 
                return RemovalCheck(originalLine, tolerance, next, curr, next, validSize);
            }
            else
            {
                return true;
            }
        }


        if (currNum == nextNum)
        {
            // increase tolerance
            ++tolerance;

            // remove a duplicate
            return RemovalCheck(line, tolerance, curr, curr, next, validSize);
        }

        if (DirectionCheck(currNum, nextNum) != isIncreasing)
        {
            // increase tolerance
            ++tolerance;
            if (tolerance > 1)
            {
                return false;
            }
            var originalLine = new List<int>(line);
            // start by removing the next number
            if (!(RemovalCheck(line, tolerance, next, curr, next, validSize)))
            {
                // get the next number back, remove the curr number
                return RemovalCheck(originalLine, tolerance, curr, curr, next, validSize);
            }
            else
            {
                return true;
            }
        }

        var removeCurrCopy = new List<int>(line);
        var removeNextCopy = new List<int>(line);

        if (!(SafetyCheck(line, tolerance, curr + 1, next + 1, DirectionCheck(line[0], line[1]), validSize)))
        {
            if (!(RemovalCheck(removeCurrCopy, tolerance, curr, curr, next, validSize)))
            {
                // increase tolerance
                ++tolerance;

                if (!(RemovalCheck(removeNextCopy, tolerance, next, curr, next, validSize)))
                {
                    // the next number back, remove the curr number
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        return true;

    }

    public static bool RemovalCheck(List<int> line, int tolerance, int index, int curr, int next, int validSize)
    {
        line.RemoveAt(index);
        // currently running over the whole list again
        // TODO: use dynamic indexing for curr and next
        return SafetyCheck(line, tolerance, 0, 1, DirectionCheck(line[0], line[1]), validSize);
    }

    public static bool DirectionCheck(int currNum, int nextNum)
    {

        if (currNum < nextNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
