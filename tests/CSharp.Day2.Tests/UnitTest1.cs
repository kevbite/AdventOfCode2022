using FluentAssertions;

namespace CSharp.Day2.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var input = @"A Y
B X
C Z";
        var totalScore = StrategyGuide.GetTotalScorePart1(input);

        totalScore.Should().Be(15);
    }
    
    [Fact]
    public void Test2()
    {
        var input = @"A Y
B X
C Z";
        var totalScore = StrategyGuide.GetTotalScorePart2(input);

        totalScore.Should().Be(12);
    }
}