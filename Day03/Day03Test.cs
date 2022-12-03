using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day03;

public class Day03Test
{
    [Test]
    public void ExamplePart1()
    {
        Day03.Solve("Day03Example.txt".ReadAll().LinesToString()).Should().Be(157);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day03.Solve("Day03.txt".ReadAll().LinesToString()));
    }

    [Test]
    public void ExamplePart2()
    {
        Day03.SolvePart2("Day03Example.txt".ReadAll().LinesToString()).Should().Be(70);
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day03.SolvePart2("Day03.txt".ReadAll().LinesToString()));
    }
}