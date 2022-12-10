namespace AdventOfCode2022.Day10;

public class Day10
{
    public static int SolvePart1(List<string> commands)
    {
        var trace = BuildTrace(commands);
        return SignalStrenthSum(trace, 20, 60, 100, 140, 180, 220);
    }

    public static List<string> SolvePart2(List<string> commands)
    {
        var output = new List<string> { "" };
        var trace = BuildTrace(commands);
        var position = 0;

        foreach (var entry in trace)
        {
            if (position % 40 == 0)
                position = 0;

            if (position >= entry.Value - 1 && position <= entry.Value + 1)
                output[^1] += "#";
            else
                output[^1] += ".";

            position++;
        }

        return output;
    }

    private static Dictionary<int, int> BuildTrace(List<string> commands)
    {
        var currentXValue = 1;
        var cycle = 1;
        var trace = new Dictionary<int, int>();

        foreach (var command in commands)
        {
            trace.Add(cycle, currentXValue);

            if (command.StartsWith("addx"))
            {
                trace.Add(cycle + 1, currentXValue);
                currentXValue += Convert.ToInt32(command.Split(" ")[1]);
                cycle += 2;
            }
            else
                cycle++;
        }

        return trace;
    }

    private static int SignalStrenthSum(Dictionary<int, int> trace, params int[] cycles) => cycles.Select(x => trace[x] * x).Sum();
}