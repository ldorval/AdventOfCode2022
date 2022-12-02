using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day02;

public class Day02Test
{
    private const string example = "A Y\r\nB X\r\nC Z";

    [Test]
    public void ExamplePart1()
    {
        Day02.Solve(example, false).Should().Be(15);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day02.Solve("Day02.txt".ReadAll(), false));
    }

    [Test]
    public void ExamplePart2()
    {
        Day02.Solve(example, true).Should().Be(12);
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day02.Solve("Day02.txt".ReadAll(), true));
    }
}