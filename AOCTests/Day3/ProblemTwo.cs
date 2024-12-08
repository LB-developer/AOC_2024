using AOC.Day3;
namespace AOC.UnitTests.Day3
{
    public class ProblemTwoTests
    {
        [Theory]
        [InlineData("do()sa=mul(42,12)q23don't()abmul(14,128)anmul(92,3)", "do()sa=mul(42,12)q23")]
        [InlineData("xmul(8,5)&mul[3,7]!^don't()don't()do()don't()_mul(500,15)don't()+mul(32,64](mul(11,8)undo()?mul(8,5))", "xmul(8,5)&mul[3,7]!^?mul(8,5))do()")]
        [InlineData("mul(8,5)", "mul(8,5)do()")]
        [InlineData("mul(8,5)don't()             12312867 don't() 123125          ", "mul(8,5)")]
        public void RemoveInvalidMulFromLine_WhenInputIsValid_ShouldReturnExpectedString(string line, string expected)
        {
            // Arrange
            var problemTwo = new ProblemTwo();
            // Act
            var actual = problemTwo.RemoveInvalidMulFromLine(line);
            // Assert
            Assert.Equal(expected, actual);
        }

    }
}

