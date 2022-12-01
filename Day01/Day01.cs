namespace AdventOfCode2022.Day01;

public class Day01
{
    public static int Solve(string input, int elfCount)
    {
        return input.Split("\r\n\r\n")
            .Select(x => x.Split("\r\n"))
            .Select(x => x.Select(y => Convert.ToInt32(y)).Sum())
            .OrderByDescending(x => x)
            .Take(elfCount)
            .Sum();
    }
}