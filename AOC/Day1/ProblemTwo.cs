
namespace AOC.Day1;

public class ProblemTwo
{

    public static int Solution()
    {

        (List<int> countOne, Dictionary<int, int> countTwo) = ListAndCountFromInput();

        int similarityScore = 0;

        foreach (var num in countOne)
        {
            similarityScore += num * countTwo.GetValueOrDefault(num);
        }

        return similarityScore;
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
