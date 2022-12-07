using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day06;

public class Day06Test
{
    [Test]
    public void ExamplePart1()
    {
        Day06.Sovle("bvwbjplbgvbhsrlpgdmjqwftvncz", 4).Should().Be(5);
        Day06.Sovle("nppdvjthqldpwncqszvftbrmjlhg", 4).Should().Be(6);
        Day06.Sovle("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4).Should().Be(10);
        Day06.Sovle("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4).Should().Be(11);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day06.Sovle("Day06.txt".ReadAll(), 4));
    }
    
    [Test]
    public void ExamplePart2()
    {
        Day06.Sovle("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14).Should().Be(19);
        Day06.Sovle("bvwbjplbgvbhsrlpgdmjqwftvncz", 14).Should().Be(23);
        Day06.Sovle("nppdvjthqldpwncqszvftbrmjlhg", 14).Should().Be(23);
        Day06.Sovle("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14).Should().Be(29);
        Day06.Sovle("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14).Should().Be(26);
    }

    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day06.Sovle("Day06.txt".ReadAll(), 14));
    }
}