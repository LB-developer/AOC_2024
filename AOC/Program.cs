﻿namespace AOC
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(AOC.Day1.ProblemOne.Solution());
            Console.WriteLine(AOC.Day1.ProblemTwo.Solution());
            Console.WriteLine(AOC.Day2.ProblemOne.Solution());
            Console.WriteLine(AOC.Day2.ProblemTwo.Solution());
            Console.WriteLine(AOC.Day3.ProblemOne.Solution());

            var Day3_ProblemTwo = new Day3.ProblemTwo();
            Console.WriteLine(Day3_ProblemTwo.Solution());
        }
    }
}
