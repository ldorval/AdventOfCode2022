using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day12;

public class Day12Test
{
    [Test]
    public void ExamplePart1()
    {
        new Day12("Day12Example.txt".ReadAll().LinesToString()).SolvePart1().Should().Be(31);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(new Day12("Day12.txt".ReadAll().LinesToString()).SolvePart1());
    }

    [Test]
    public void ExamplePart2()
    {
        new Day12("Day12Example.txt".ReadAll().LinesToString()).SolvePart2().Should().Be(29);
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.Write(new Day12("Day12.txt".ReadAll().LinesToString()).SolvePart2());
    }
}