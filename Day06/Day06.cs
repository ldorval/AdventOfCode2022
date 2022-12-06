namespace AdventOfCode2022.Day06;

public class Day06
{
    public static int Sovle(string datastream, int markerSize)
    {
        for (var i = 0; i < datastream.Length - markerSize; i++)
        {
            var letters = datastream.Skip(i).Take(markerSize);
            if (letters.GroupBy(x => x).Count() == markerSize)
                return i + markerSize;
        }
        
        return 0;
    }
}