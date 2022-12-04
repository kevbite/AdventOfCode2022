var input = File.ReadAllText("input.txt");

Console.WriteLine("Day 1");
Console.WriteLine("Part 1");
Console.WriteLine(StrategyGuide.GetTotalScorePart1(input));
Console.WriteLine();


Console.WriteLine("Part 2");
Console.WriteLine(StrategyGuide.GetTotalScorePart2(input));
Console.WriteLine();

public static class StrategyGuide
{
    public static int GetTotalScorePart1(string input) =>
        input.Split(Environment.NewLine)
            .Select(Part1GameRound.FromLine)
            .Sum(x => x.GetScore());
    
    public static int GetTotalScorePart2(string input) =>
        input.Split(Environment.NewLine)
            .Select(Part2GameRound.FromLine)
            .Sum(x => x.GetScore());

    public abstract class GameRound
    {
        private readonly string _rawLeft;
        protected readonly string RawRight;

        public GameRound(string rawLeft, string rawRight)
        {
            _rawLeft = rawLeft;
            RawRight = rawRight;
        }

        public GameOption Opponent => _rawLeft switch
        {
            "A" => GameOption.Rock,
            "B" => GameOption.Paper,
            "C" => GameOption.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        public abstract GameOption You { get; }

        public abstract GameRoundResult Result { get; }
        
        public int GetScore()
        {
            var selectedShapeScore = You switch
            {
                GameOption.Rock => 1,
                GameOption.Paper => 2,
                GameOption.Scissors => 3,
                _ => throw new ArgumentOutOfRangeException()
            };

            var outcomeScore = Result switch
            {
                GameRoundResult.Win => 6,
                GameRoundResult.Lose => 0,
                GameRoundResult.Draw => 3,
                _ => throw new ArgumentOutOfRangeException()
            };

            return selectedShapeScore + outcomeScore;
        }
    }
    
    

    private class Part1GameRound : GameRound
    {
        public Part1GameRound(string rawLeft, string rawRight)
            : base(rawLeft, rawRight)
        {
        }

        public static Part1GameRound FromLine(string line)
        {
            var strings = line.Split(" ");

            return new Part1GameRound(strings[0], strings[1]);
        }

        public override GameOption You => RawRight switch
        {
            "X" => GameOption.Rock,
            "Y" => GameOption.Paper,
            "Z" => GameOption.Scissors,
            _ => throw new ArgumentOutOfRangeException()
        };

        public override GameRoundResult Result => (Opponent, You) switch
        {
            (GameOption.Rock, GameOption.Paper) => GameRoundResult.Win,
            (GameOption.Paper, GameOption.Scissors) => GameRoundResult.Win,
            (GameOption.Scissors, GameOption.Rock) => GameRoundResult.Win,
            (GameOption.Rock, GameOption.Rock) => GameRoundResult.Draw,
            (GameOption.Paper, GameOption.Paper) => GameRoundResult.Draw,
            (GameOption.Scissors, GameOption.Scissors) => GameRoundResult.Draw,
            _ => GameRoundResult.Lose
        };
    }

    private class Part2GameRound : GameRound
    {
        public Part2GameRound(string rawLeft, string rawRight)
            : base(rawLeft, rawRight)
        {
        }

        public static Part2GameRound FromLine(string line)
        {
            var strings = line.Split(" ");

            return new Part2GameRound(strings[0], strings[1]);
        }

        public override GameOption You => (Opponent, Result) switch
        {
            (GameOption.Rock, GameRoundResult.Lose) => GameOption.Scissors,
            (GameOption.Paper, GameRoundResult.Lose) => GameOption.Rock,
            (GameOption.Scissors, GameRoundResult.Lose) => GameOption.Paper,
            (GameOption.Rock, GameRoundResult.Draw) => GameOption.Rock,
            (GameOption.Paper, GameRoundResult.Draw) => GameOption.Paper,
            (GameOption.Scissors, GameRoundResult.Draw) => GameOption.Scissors,
            (GameOption.Rock, GameRoundResult.Win) => GameOption.Paper,
            (GameOption.Paper, GameRoundResult.Win) => GameOption.Scissors,
            (GameOption.Scissors, GameRoundResult.Win) => GameOption.Rock,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        public override GameRoundResult Result => RawRight switch
        {
            "X" => GameRoundResult.Lose,
            "Y" => GameRoundResult.Draw,
            "Z" => GameRoundResult.Win,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public enum GameOption
    {
        Rock,
        Paper,
        Scissors
    }

    public enum GameRoundResult
    {
        Win,
        Lose,
        Draw
    }
}