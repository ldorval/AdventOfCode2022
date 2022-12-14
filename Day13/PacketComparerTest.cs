using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day13;

public class PacketComparerTest
{
    private PacketComparer comparer;

    [SetUp]
    public void ThisComparer()
    {
        comparer = new PacketComparer();
    }
    
    [Test]
    public void ComparesNumbers()
    {
        comparer.Compare(JsonDocument.Parse("1").RootElement, JsonDocument.Parse("2").RootElement).Should().Be(-1);
        comparer.Compare(JsonDocument.Parse("2").RootElement, JsonDocument.Parse("1").RootElement).Should().Be(1);
    }
    
    [Test]
    public void ComparesNumberToArray()
    {
        comparer.Compare(JsonDocument.Parse("1").RootElement, JsonDocument.Parse("[2]").RootElement).Should().Be(-1);
        comparer.Compare(JsonDocument.Parse("[1]").RootElement, JsonDocument.Parse("2").RootElement).Should().Be(-1);
        comparer.Compare(JsonDocument.Parse("[2]").RootElement, JsonDocument.Parse("1").RootElement).Should().Be(1);
        comparer.Compare(JsonDocument.Parse("2").RootElement, JsonDocument.Parse("[1]").RootElement).Should().Be(1);
    }

    [Test]
    public void ComparesUnevenArrays()
    {
        comparer.Compare(JsonDocument.Parse("[1,2]").RootElement, JsonDocument.Parse("[2]").RootElement).Should().Be(-1);
        comparer.Compare(JsonDocument.Parse("[2]").RootElement, JsonDocument.Parse("[1,2]").RootElement).Should().Be(1);
    }

    [Test]
    public void CompareUnevenEqualArrays()
    {
        comparer.Compare(JsonDocument.Parse("[7,7,7]").RootElement, JsonDocument.Parse("[7,7,7,7]").RootElement).Should().Be(-1);
        comparer.Compare(JsonDocument.Parse("[7,7,7,7]").RootElement, JsonDocument.Parse("[7,7,7]").RootElement).Should().Be(1);
    }

    [Test]
    public void ComparesMultipleArrays()
    {
        comparer.Compare(JsonDocument.Parse("[[1],[2,3,4]]").RootElement, JsonDocument.Parse("[[1],4]").RootElement).Should().Be(-1);
        comparer.Compare(JsonDocument.Parse("[[1],4]").RootElement, JsonDocument.Parse("[[1],[2,3,4]]").RootElement).Should().Be(1);
    }

    [Test]
    public void ComparesEmptyArrays()
    {
        comparer.Compare(JsonDocument.Parse("[[[]]]").RootElement, JsonDocument.Parse("[[]]").RootElement).Should().Be(1);
        comparer.Compare(JsonDocument.Parse("[[]]").RootElement, JsonDocument.Parse("[[[]]]").RootElement).Should().Be(-1);
        comparer.Compare(JsonDocument.Parse("0").RootElement, JsonDocument.Parse("[]").RootElement).Should().Be(1);
    }
}