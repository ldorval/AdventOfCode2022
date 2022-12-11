using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day11;

public class Day11Test
{
    private List<Monkey> monkeysExample;

    private List<Monkey> monkeys;

    [SetUp]
    public void Setup()
    {
        monkeysExample = new()
        {
            new() { Id = 0, Items = new() { 79, 98 }, Operation = old => old * 19, DivisibleBy = 23, MonkeyWhenTrue = 2, MonkeyWhenFalse = 3 },
            new() { Id = 1, Items = new() { 54, 65, 75, 74 }, Operation = old => old + 6, DivisibleBy = 19, MonkeyWhenTrue = 2, MonkeyWhenFalse = 0 },
            new() { Id = 2, Items = new() { 79, 60, 97 }, Operation = old => old * old, DivisibleBy = 13, MonkeyWhenTrue = 1, MonkeyWhenFalse = 3 },
            new() { Id = 3, Items = new() { 74 }, Operation = old => old + 3, DivisibleBy = 17, MonkeyWhenTrue = 0, MonkeyWhenFalse = 1 }
        };

        monkeys = new()
        {
            new() { Id = 0, Items = new() { 73, 77 }, Operation = old => old * 5, DivisibleBy = 11, MonkeyWhenTrue = 6, MonkeyWhenFalse = 5 },
            new() { Id = 1, Items = new() { 57, 88, 80 }, Operation = old => old + 5, DivisibleBy = 19, MonkeyWhenTrue = 6, MonkeyWhenFalse = 0 },
            new() { Id = 2, Items = new() { 61, 81, 84, 69, 77, 88 }, Operation = old => old * 19, DivisibleBy = 5, MonkeyWhenTrue = 3, MonkeyWhenFalse = 1 },
            new() { Id = 3, Items = new() { 78, 89, 71, 60, 81, 84, 87, 75 }, Operation = old => old + 7, DivisibleBy = 3, MonkeyWhenTrue = 1, MonkeyWhenFalse = 0 },
            new() { Id = 4, Items = new() { 60, 76, 90, 63, 86, 87, 89 }, Operation = old => old + 2, DivisibleBy = 13, MonkeyWhenTrue = 2, MonkeyWhenFalse = 7 },
            new() { Id = 5, Items = new() { 88 }, Operation = old => old + 1, DivisibleBy = 17, MonkeyWhenTrue = 4, MonkeyWhenFalse = 7 },
            new() { Id = 6, Items = new() { 84, 98, 78, 85 }, Operation = old => old * old, DivisibleBy = 7, MonkeyWhenTrue = 5, MonkeyWhenFalse = 4 },
            new() { Id = 7, Items = new() { 98, 89, 78, 73, 71 }, Operation = old => old + 4, DivisibleBy = 2, MonkeyWhenTrue = 3, MonkeyWhenFalse = 2 }
        };
    }
    
    [Test]
    public void ExamplePart1()
    {
        Day11.Solve(monkeysExample, 20).Should().Be(10605);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day11.Solve(monkeys, 20));
    }

    [Test]
    public void ExamplePart2()
    {
        Day11.Solve(monkeysExample, 10000).Should().Be(2713310158);
    }

    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day11.Solve(monkeys, 10000));
    }
}