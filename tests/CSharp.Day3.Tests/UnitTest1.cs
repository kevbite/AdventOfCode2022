using FluentAssertions;

namespace CSharp.Day3.Tests;

public class UnitTest1
{
    private readonly string _input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

    [Fact]
    public void Test1()
    {
        var rucksacks = Rucksacks.From(_input);

        rucksacks.SumOfPriorities().Should().Be(157);
    }


    [Fact]
    public void Test2()
    {
        var rucksacks = RucksackGroups.From(_input);

        rucksacks.SumOfPriorities().Should().Be(70);
    }
}