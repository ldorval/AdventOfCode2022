using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day13;

public class Day13Test
{
    [Test]
    public void ExamplePart1()
    {
        Day13.SolvePart1("Day13Example.txt".ReadAll()).Should().Be(13);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day13.SolvePart1("Day13.txt".ReadAll()));
    }

    [Test]
    public void ExamplePart2()
    {
        Day13.SolvePart2("Day13Example.txt".ReadAll()).Should().Be(140);
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day13.SolvePart2("Day13.txt".ReadAll()));
    }
}
