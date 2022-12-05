using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day05;

public class Day05Test
{
    private Dictionary<int, Stack<char>> exampleStacks = new()
    {
        { 1, new Stack<char>(new List<char> { 'Z', 'N' }) },
        { 2, new Stack<char>(new List<char> { 'M', 'C', 'D' }) },
        { 3, new Stack<char>(new List<char> { 'P' }) }
    };
    
    private Dictionary<int, Stack<char>> stacks = new()
    {
        { 1, new Stack<char>(new List<char> { 'Q', 'W', 'P', 'S', 'Z', 'R', 'H', 'D' }) },
        { 2, new Stack<char>(new List<char> { 'V', 'B', 'R', 'W', 'Q', 'H', 'F' }) },
        { 3, new Stack<char>(new List<char> { 'C', 'V', 'S', 'H' }) },
        { 4, new Stack<char>(new List<char> { 'H', 'F', 'G' }) },
        { 5, new Stack<char>(new List<char> { 'P', 'G', 'J', 'B', 'Z' }) },
        { 6, new Stack<char>(new List<char> { 'Q', 'T', 'J', 'H', 'W', 'F', 'L' }) },
        { 7, new Stack<char>(new List<char> { 'Z', 'T', 'W', 'D', 'L', 'V', 'J', 'N' }) },
        { 8, new Stack<char>(new List<char> { 'D', 'T', 'Z', 'C', 'J', 'G', 'H', 'F' }) },
        { 9, new Stack<char>(new List<char> { 'W', 'P', 'V', 'M', 'B', 'H' }) },
    };
    
    [Test]
    public void ExamplePart1()
    {
        Day05.Solve(exampleStacks, "Day05Example.txt".ReadAll().LinesToString()).Should().Be("CMZ");
    }

    [Test]
    public void ParsesInstructions()
    {
        Day05.GetInstructions(new List<string> { "move 3 from 1 to 3", "move 2 from 2 to 1" }).Should().BeEquivalentTo(new List<object> {(3, 1, 3), (2, 2, 1)});
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day05.Solve(stacks, "Day05.txt".ReadAll().LinesToString()));
    }

    [Test]
    public void ExamplePart2()
    {
        Day05.SolvePart2(exampleStacks, "Day05Example.txt".ReadAll().LinesToString()).Should().Be("MCD");
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day05.SolvePart2(stacks, "Day05.txt".ReadAll().LinesToString()));
    }
}