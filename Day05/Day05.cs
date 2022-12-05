namespace AdventOfCode2022.Day05;

public class Day05
{
    public static string Solve(Dictionary<int,Stack<char>> stacks, List<string> inputLines)
    {
        GetInstructions(inputLines).ForEach(x =>
        {
            for (var i = 0; i < x.count; i++)
            {
                var crate = stacks[x.from].Pop();
                stacks[x.to].Push(crate);
            }
        });
        
        return GetTopOfStacks(stacks);
    }

    public static string SolvePart2(Dictionary<int, Stack<char>> stacks, List<string> inputLines)
    {
        GetInstructions(inputLines).ForEach(x =>
        {
            var poppedCrates = new List<char>();
            for (var i = 0; i < x.count; i++)
            {
                poppedCrates.Add(stacks[x.from].Pop());
            }

            poppedCrates.Reverse();
            poppedCrates.ForEach(y => stacks[x.to].Push(y));
        });
        return GetTopOfStacks(stacks);
    }

    private static string GetTopOfStacks(Dictionary<int, Stack<char>> stacks)
    {
        var output = "";
        
        for (var i = 1; i <= stacks.Count; i++)
        {
            output += stacks[i].Pop();
        }

        return output;
    }

    public static List<(int count, int from, int to)> GetInstructions(List<string> inputLines)
    {
        return inputLines.Select(x =>
        {
            var count = Convert.ToInt32(x.Substring(4, x.IndexOf("from") - 4));
            var from = Convert.ToInt32(x.Substring(x.IndexOf("from") + 4, x.IndexOf("to") - x.IndexOf("from") - 4));
            var to = Convert.ToInt32(x.Substring(x.IndexOf("to") + 2, x.Length - x.IndexOf("to") - 2));
            return (count, from, to);
        }).ToList();
    }
}