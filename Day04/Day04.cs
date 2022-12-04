namespace AdventOfCode2022.Day04;

public class Day04
{
    public static int Solve(List<string> input)
    {
        return input
            .Select(x => x.Split(","))
            .Count(x => OneAssignmentContainsTheOther(GetRange(x[0]), GetRange(x[1])));
    }

    public static int SolvePart2(List<string> input)
    {
        return input
            .Select(x => x.Split(","))
            .Count(x => AssignmentsOverlap(GetRange(x[0]), GetRange(x[1])));
    }

    public static bool OneAssignmentContainsTheOther((int Start, int End) elf1, (int Start, int End) elf2)
    {
        return (elf1.Start <= elf2.Start && elf1.End >= elf2.End) ||
               (elf2.Start <= elf1.Start && elf2.End >= elf1.End);
    }

    public static bool AssignmentsOverlap((int Start, int End) elf1, (int Start, int End) elf2)
    {
        return (elf1.End >= elf2.Start && elf1.Start <= elf2.End) ||
               (elf2.End >= elf1.Start && elf2.Start <= elf1.End);
    }

    public static (int Start, int End) GetRange(string assignment)
    {
        var parts = assignment.Split("-");
        return (Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
    }
}
