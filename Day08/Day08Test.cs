using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day08;

public class Day08Test
{
    private const string example = "30373\r\n25512\r\n65332\r\n33549\r\n35390";
    
    [Test]
    public void ExamplePart1()
    {
        Day08.SolvePart1(example.LinesToString()).Should().Be(21);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day08.SolvePart1("Day08.txt".ReadAll().LinesToString()));
    }
    
    [Test]
    public void ExamplePart2()
    {
        Day08.SolvePart2(example.LinesToString()).Should().Be(8);
    }

    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day08.SolvePart2("Day08.txt".ReadAll().LinesToString()));
    }
}