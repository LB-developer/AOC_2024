
namespace AOC.UnitTests.Day2
{
    public class ProblemTwo_EdgeCasesShould
    {
        public static IEnumerable<object[]> FailData()
        {
            yield return new object[] { new List<int> { 1, 1, 1, 1 } };
            yield return new object[] { new List<int> { 1, 2, 6, 11 } };
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5, 5, 5 } };
            yield return new object[] { new List<int> { 90, 89, 91, 93, 95, 94 } };
            yield return new object[] { new List<int> { 80, 81, 83, 84, 88, 91 } };
        }

        [Theory]
        [MemberData(nameof(FailData))]
        public void EdgeCases_ReturnFalse(List<int> line)
        {
            // Assign
            bool expected = false;

            // Act
            (List<int> inputLine, int tolerance, int curr, int next, bool isIncreasing, int validSize) = AOC.Day2.ProblemTwo.InputCalculator(line);
            bool actual = AOC.Day2.ProblemTwo.SafetyCheck(inputLine, tolerance, curr, next, isIncreasing, validSize);


            // Assert
            Assert.Equal(expected, actual);


        }

        public static IEnumerable<object[]> SuccessData()
        {
            yield return new object[] { new List<int> { 2, 1, 2, 5 } };
            yield return new object[] { new List<int> { 1, 4, 3, 2, 1, } };
            yield return new object[] { new List<int> { 2, 5, 4, 3, 2, } };
            yield return new object[] { new List<int> { 1, 6, 7, 8, 9, } };
            yield return new object[] { new List<int> { 1, 2, 3, 4, 3, } };
            yield return new object[] { new List<int> { 9, 8, 7, 6, 7, } };
            yield return new object[] { new List<int> { 1, 1, 2, 3, 4, 5, } };
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5, 5, } };
            yield return new object[] { new List<int> { 7, 10, 8, 10, 11, } };
            yield return new object[] { new List<int> { 5, 1, 2, 3, 4, 5, } };
            yield return new object[] { new List<int> { 97, 96, 93, 91, 85, } };
            yield return new object[] { new List<int> { 29, 26, 24, 25, 21, } };
            yield return new object[] { new List<int> { 36, 37, 40, 43, 47, } };
            yield return new object[] { new List<int> { 77, 76, 73, 70, 64, } };
            yield return new object[] { new List<int> { 70, 73, 76, 79, 86, } };
            yield return new object[] { new List<int> { 75, 77, 72, 70, 69, } };
            yield return new object[] { new List<int> { 16, 19, 21, 24, 23, } };
            yield return new object[] { new List<int> { 90, 89, 86, 84, 83, 79, } };
            yield return new object[] { new List<int> { 43, 44, 47, 48, 49, 54, } };
            yield return new object[] { new List<int> { 52, 51, 52, 49, 47, 45, } };
            yield return new object[] { new List<int> { 48, 46, 47, 49, 51, 54, 56, } };
            yield return new object[] { new List<int> { 37, 40, 42, 43, 44, 47, 51, } };
            yield return new object[] { new List<int> { 29, 28, 27, 25, 26, 25, 22, 20, } };
            yield return new object[] { new List<int> { 35, 33, 31, 29, 27, 25, 22, 18, } };
            yield return new object[] { new List<int> { 68, 65, 69, 72, 74, 77, 80, 83, } };
            yield return new object[] { new List<int> { 31, 34, 32, 30, 28, 27, 24, 22, } };
        }

        [Theory]
        [MemberData(nameof(SuccessData))]
        public void EdgeCases_ReturnTrue(List<int> line)
        {
            // Assign
            bool expected = true;

            // Act
            (List<int> inputLine, int tolerance, int curr, int next, bool isIncreasing, int validSize) = AOC.Day2.ProblemTwo.InputCalculator(line);
            bool actual = AOC.Day2.ProblemTwo.SafetyCheck(inputLine, tolerance, curr, next, isIncreasing, validSize);


            // Assert
            Assert.Equal(expected, actual);


        }
    }
}
