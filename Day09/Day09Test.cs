using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day09;

public class Day09Test
{
    [Test]
    public void ExamplePart1()
    {
        new Day09().Solve("Day09Example.txt".ReadAll().LinesToString(), 2).Should().Be(13);
    }

    [Test]
    public void SolutuionPart1()
    {
        Console.Write(new Day09().Solve("Day09.txt".ReadAll().LinesToString(), 2));
    }

    [Test]
    public void ExamplePart2()
    {
        new Day09().Solve("Day09Example2.txt".ReadAll().LinesToString(), 10).Should().Be(36);
    }

    [Test]
    public void SolutionPart2()
    {
        Console.Write(new Day09().Solve("Day09.txt".ReadAll().LinesToString(), 10));
    }
}