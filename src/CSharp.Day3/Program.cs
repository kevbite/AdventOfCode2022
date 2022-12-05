var input = File.ReadAllText("input.txt");

Console.WriteLine("Day 1");
Console.WriteLine("Part 1");
Console.WriteLine(Rucksacks.From(input).SumOfPriorities());
Console.WriteLine();


Console.WriteLine("Part 2");
Console.WriteLine(RucksackGroups.From(input).SumOfPriorities());
Console.WriteLine();


public class RucksackGroups
{
    private readonly string _input;

    private RucksackGroups(string input)
    {
        _input = input;
    }

    public static RucksackGroups From(string input) =>
        new(input);


    public int SumOfPriorities()
    {
        return _input.Split(Environment.NewLine)
            .Chunk(3)
            .Select(group =>
                group[0].Where(c => group[1].Contains(c) && group[2].Contains(c))
                .Distinct().Single())
            .Sum(ItemPriorityConvertor.GetPriority);
    }
}

public class Rucksacks
{
    private readonly IReadOnlyCollection<Rucksack> _rucksacks;

    private Rucksacks(IReadOnlyCollection<Rucksack> rucksacks)
    {
        _rucksacks = rucksacks;
    }

    public static Rucksacks From(string input) =>
        new(input.Split(Environment.NewLine).Select(x => new Rucksack(x)).ToArray());

    public int SumOfPriorities()
        => _rucksacks.Sum(x => x.SumOfPriorities());
}

public class Rucksack
{
    private readonly string _input;

    public Rucksack(string input)
    {
        _input = input;
    }

    public int SumOfPriorities()
    {
        var firstCompartment = _input[..(_input.Length / 2)];
        var secondCompartment = _input[^(_input.Length / 2)..];

        var matchingChar = secondCompartment.Where(x => firstCompartment.Contains(x))
            .Distinct().Single();

        return ItemPriorityConvertor.GetPriority(matchingChar);
    }
    
}

public static class ItemPriorityConvertor
{
    public static int GetPriority(char input)
    {
        return input switch
        {
            >= 'a' and <= 'z' => input - 'a' + 1,
            >= 'A' and <= 'Z' => input - 'A' + 27,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}