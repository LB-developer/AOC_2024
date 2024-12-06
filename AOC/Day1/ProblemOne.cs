

namespace AOC.Day1;

public class ProblemOne
{
    public static int Solution()
    {

        (List<int> listOne, List<int> listTwo) = SortedListsFromInput();

        var distance = 0;
        for (var i = 0; i < listOne.Count; ++i)
        {
            distance += Math.Abs(listOne[i] - listTwo[i]);
        }


        return distance;
    }

    public static Tuple<List<int>, List<int>> SortedListsFromInput()
    {
        List<int> listOne = [];
        List<int> listTwo = [];

        using (StreamReader reader = new StreamReader("Day1/input.txt"))
        {
            string[]? line;

            while ((line = reader.ReadLine()?.Split("   ")) != null)
            {
                var list = 1;
                foreach (string a in line)
                {
                    if (a != "")
                    {
                        (list == 1 ? listOne : listTwo).Add(Int32.Parse(a));
                        ++list;
                    }
                }
            }


        }

        listOne.Sort();
        listTwo.Sort();

        return Tuple.Create(listOne, listTwo);
    }

    public static Tuple<List<int>, Dictionary<int, int>> ListAndCountFromInput()
    {
        List<int> listOne = new List<int>();
        Dictionary<int, int> countListTwo = new Dictionary<int, int>();

        using (StreamReader reader = new StreamReader("Day1/input.txt"))
        {
            string[]? line;

            while ((line = reader.ReadLine()?.Split("   ")) != null)
            {
                var list = 1;
                foreach (string a in line)
                {
                    if (a != "")
                    {
                        int currNum = int.Parse(a);
                        if (list == 1)
                        {
                            listOne.Add(currNum);
                        }
                        else
                        {
                            if (countListTwo.ContainsKey(currNum))
                            {
                                countListTwo[currNum]++;
                            }
                            else
                            {
                                countListTwo[currNum] = 1;
                            }
                        }

                        ++list;
                    }
                }
            }
        }

        return Tuple.Create(listOne, countListTwo);
    }

}
