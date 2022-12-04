using FluentAssertions;

namespace CSharp.Day1.Tests;

public class UnitTest1
{
    private readonly string _input;

    public UnitTest1()
    {
        _input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
        
    }
    
    [Fact]
    public void ShouldReturnMaxElfCalories()
    {
        var actual = ElfCaloriesCalculator.CalculateMax(_input);

        actual.Should().Be(24000);
    }
    
    [Fact]
    public void ShouldReturnTop3ElfCaloriesSum()
    {
        var actual = ElfCaloriesCalculator.CalculateTopThreeElvesCalories(_input);

        actual.Should().Be(45000);
    }
    
}