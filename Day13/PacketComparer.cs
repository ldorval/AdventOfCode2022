using System.Text.Json;

namespace AdventOfCode2022.Day13;

public class PacketComparer : IComparer<JsonElement>
{
    public int Compare(JsonElement left, JsonElement right)
    {
        if (left.ValueKind == JsonValueKind.Number && right.ValueKind == JsonValueKind.Number)
            return (left.GetInt32() - right.GetInt32()) switch { 0 => 0, > 0 => 1, < 0 => -1 };

        if (left.ValueKind == JsonValueKind.Number && right.ValueKind == JsonValueKind.Array)
            return Compare(WrapInArray(left), right);

        if (left.ValueKind == JsonValueKind.Array && right.ValueKind == JsonValueKind.Number)
            return Compare(left, WrapInArray(right));

        var leftArray = left.EnumerateArray().ToList();
        var rightArray = right.EnumerateArray().ToList();

        var i = 0;

        while (i < leftArray.Count && i < rightArray.Count)
        {
            var result = Compare(leftArray[i], rightArray[i]);
            if (result != 0) return result;
            i++;
        }

        return CompareArraysLength(leftArray, rightArray);
    }

    private static JsonElement WrapInArray(JsonElement element)
    {
        return JsonDocument.Parse($"[{element.GetInt32()}]").RootElement;
    }

    private static int CompareArraysLength(List<JsonElement> leftArray, List<JsonElement> rightArray)
    {
        if (leftArray.Count > rightArray.Count) return 1;
        if (rightArray.Count > leftArray.Count) return -1;

        return 0;
    }
}