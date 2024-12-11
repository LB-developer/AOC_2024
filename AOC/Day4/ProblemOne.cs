
namespace AOC.Day4;

public class ProblemOne
{

    Dictionary<string, string> followingLetters = new Dictionary<string, string>
       {
            {"M", "A"},
            {"A" , "S"}
       };
    List<string[]> inputList = new List<string[]>();

    public int Solution()
    {

        int total = 0;

        using (StreamReader reader = new StreamReader("Day4/input.txt"))
        {
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                inputList.Add(line.Split());
            }
        }


        var directions = new List<(int y, int x)>
        {//   y  x
            ( 0, 1 ),   // right
            ( 1, 0 ),   // down
            ( 0, -1 ),  // left
            ( -1, 0 ),  // up
            ( 1, 1 ),   // bottom-right diagonal
            ( -1, -1 ), // top-left diagonal
            ( -1, 1 ),  // top-right diagonal
            ( 1, -1 )   // bottom-left diagonal
        };


        for (var line = 0; line < inputList.Count(); ++line)
        {
            for (var y = 0; y < inputList.Count(); ++y)
            {
                for (var x = 0; x < inputList[y].Count(); ++x)
                {

                    var currentLetter = inputList[line][y][x];

                    if (currentLetter == "X")
                    {
                        Console.WriteLine("Found an X");
                        foreach (var direction in directions)
                        {

                            if (CheckDirections(y, x, direction, currentLetter, "M"))
                            {

                                ++total;

                            }
                        }
                    }
                }
            }
        }


        return total;

    }

    internal bool CheckDirections(int x, int y, (int, int) movement, string currentLetter, string desiredLetter)
    {
        (int moveX, int moveY) = movement;
        try
        {
            if (currentLetter == "S")
            {
                return true;
            }

            currentLetter = inputList[x][y];

            if (desiredLetter != currentLetter)
            {
                return false;
            }


            return CheckDirections(x + moveX, y + moveY, movement, currentLetter, followingLetters[currentLetter]);
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
}
