using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day10;

public class Day10Test
{
    [Test]
    public void ExamplePart1()
    {
        Day10.SolvePart1("Day10Example.txt".ReadAll().LinesToString()).Should().Be(13140);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day10.SolvePart1("Day10.txt".ReadAll().LinesToString()));
    }

    [Test]
    public void ExamplePart2()
    {
        var lines = Day10.SolvePart2("Day10Example.txt".ReadAll().LinesToString());
        lines.ForEach(Console.WriteLine);
    }

    [Test]
    public void SolutionPart2()
    {
        var lines = Day10.SolvePart2("Day10.txt".ReadAll().LinesToString());
        lines.ForEach(Console.WriteLine);
    }
}