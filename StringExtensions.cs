namespace AdventOfCode2022;

public static class StringExtensions
{
    public static List<int> ToInts(this string value)
    {
        return value.Split(",").Select(int.Parse).ToList();
    }

    public static List<List<int>> ToIntMap(this string value)
    {
        return value.LinesToString()
            .Select(x => x.ToCharArray()
                .Select(x => Convert.ToInt32(Char.GetNumericValue(x))).ToList())
            .ToList();
    }

    public static List<int> LinesToInts(this string value)
    {
        return value
            .Split("\r\n")
            .Select(x => Convert.ToInt32(x))
            .ToList();
    }
        
    public static List<string> LinesToString(this string value)
    {
        return value.Split("\r\n").ToList();
    }
}