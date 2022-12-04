// See https://aka.ms/new-console-template for more information

var input = File.ReadAllText("input.txt");

Console.WriteLine("Day 1");
Console.WriteLine("Part 1");
Console.WriteLine(ElfCaloriesCalculator.CalculateMax(input));
Console.WriteLine();

Console.WriteLine("Part 2");
Console.WriteLine(ElfCaloriesCalculator.CalculateTopThreeElvesCalories(input));



public static class ElfCaloriesCalculator
{
    public static int CalculateMax(string input) =>
        input.Split(Environment.NewLine + Environment.NewLine)
            .Max(x => x.Split(Environment.NewLine).Select(int.Parse).Sum());

    public static int CalculateTopThreeElvesCalories(string input) =>
        input.Split(Environment.NewLine + Environment.NewLine)
            .Select(x => x.Split(Environment.NewLine).Select(int.Parse).Sum())
            .OrderDescending()
            .Take(3)
            .Sum();
} 