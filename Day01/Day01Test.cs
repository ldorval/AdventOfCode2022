using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day01;

public class Day01Test
{
    private const string example = "1000\r\n2000\r\n3000\r\n\r\n4000\r\n\r\n5000\r\n6000\r\n\r\n7000\r\n8000\r\n9000\r\n\r\n10000";
    
    [Test]
    public void ExamplePart1()
    {
        Day01.Solve(example, 1).Should().Be(24000);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.WriteLine(Day01.Solve("Day01.txt".ReadAll(), 1));
    }

    [Test]
    public void ExamplePart2()
    {
        Day01.Solve(example, 3).Should().Be(45000);
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.WriteLine(Day01.Solve("Day01.txt".ReadAll(), 3));
    }
}