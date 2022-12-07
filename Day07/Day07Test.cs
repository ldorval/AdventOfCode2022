using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day07;

public class Day07Test
{
    [Test]
    public void ExamplePart1()
    {
        Day07.SolvePart1("Day07Example.txt".ReadAll().LinesToString()).Should().Be(95437);
    }

    [Test]
    public void BuildsDirectoryList()
    {
        Day07.BuildDirectoryList("Day07Example.txt".ReadAll().LinesToString()).Should().BeEquivalentTo(new Dictionary<string, long>
        {
            { "/", 14848514 + 8504156 },
            { "/a/", 29116 + 2557 + 62596 },
            { "/a/e/", 584 },
            { "/d/", 4060174 + 8033020 + 5626152 + 7214296 }
        });
    }

    [Test]
    public void GetsDirectorySize()
    {
        var directories = Day07.BuildDirectoryList("Day07Example.txt".ReadAll().LinesToString());
        Day07.GetDirectoryTotalSize("/", directories).Should().Be(48381165);
        Day07.GetDirectoryTotalSize("/a/", directories).Should().Be(94853);
        Day07.GetDirectoryTotalSize("/a/e/", directories).Should().Be(584);
        Day07.GetDirectoryTotalSize("/d/", directories).Should().Be(24933642);
    }

    [Test]
    public void CanGetParentPath()
    {
        Day07.GetParentPath("/a/b/c/").Should().Be("/a/b/");
        Day07.GetParentPath("/a/").Should().Be("/");
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day07.SolvePart1("Day07.txt".ReadAll().LinesToString()));
    }

    [Test]
    public void ExamplePart2()
    {
        Day07.SolvePart2("Day07Example.txt".ReadAll().LinesToString()).Should().Be(24933642);
    }

    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day07.SolvePart2("Day07.txt".ReadAll().LinesToString()));
    }
}