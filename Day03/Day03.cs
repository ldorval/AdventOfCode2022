namespace AdventOfCode2022.Day03;

public class Day03
{
    public static int Solve(List<string> ruckSacks)
    {
        return ruckSacks
            .Select(x => new List<List<char>> { x.Take(x.Length / 2).ToList(), x.TakeLast(x.Length / 2).ToList() })
            .Select(x => x.First().Intersect(x.Last()).Single())
            .Select(GetPriority)
            .Sum();
    }

    public static int SolvePart2(List<string> ruckSacks)
    {
        var groups = new List<List<string>>();
        
        for (var i = 0; i < ruckSacks.Count; i += 3)
        {
            groups.Add(ruckSacks.Skip(i).Take(3).ToList());
        }

        return groups
            .Select(x => x.Select(y => y.ToCharArray()))
            .Select(x => x.Aggregate((a, b) => a.Intersect(b).ToArray()).Single())
            .Select(GetPriority)
            .Sum();
    }

    private static int GetPriority(char x)
    {
        return char.IsUpper(x) ? x - 38 : x - 96;
    }
}