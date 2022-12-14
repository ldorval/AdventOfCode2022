using System.Text.Json;

namespace AdventOfCode2022.Day13;

public class Day13
{
    public static int SolvePart1(string input)
    {
        var comparer = new PacketComparer();
        return input.Split("\r\n\r\n")
            .Select(x => x.Split("\r\n"))
            .Select(x => comparer.Compare(JsonDocument.Parse(x[0]).RootElement, JsonDocument.Parse(x[1]).RootElement))
            .Select((x, i) => (result: x, index: i + 1))
            .Where(x => x.result == -1)
            .Sum(x => x.index);
    }

    public static int SolvePart2(string input)
    {
        var comparer = new PacketComparer();
        var packets = input
            .Split("\r\n")
            .Where(x => x != "")
            .Select(x => JsonDocument.Parse(x).RootElement)
            .ToList();
        
        packets.Add(JsonDocument.Parse("[[2]]").RootElement);
        packets.Add(JsonDocument.Parse("[[6]]").RootElement);

        var orderedPackets = packets.OrderBy(x => x, comparer).ToList();
        return GetIndexOf(orderedPackets, "[[2]]") * GetIndexOf(orderedPackets, "[[6]]");
    }

    private static int GetIndexOf(IEnumerable<JsonElement> orderedPackets, string json)
    {
        return orderedPackets.Select((packet, i) => (packet, i))
            .Where(x => x.packet.ToString() == json).
            Select(x => x.i + 1)
            .Single();
    }
}