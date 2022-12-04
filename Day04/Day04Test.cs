using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022.Day04;

public class Day04Test
{
    [Test]
    public void GetsElfAssignmentRange()
    {
        Day04.GetRange("1-4").Should().Be((1, 4));
        Day04.GetRange("43-54").Should().Be((43, 54));
    }

    [Test]
    public void ValidatesIfOneAssignmentContainsTheOther()
    {
        Day04.OneAssignmentContainsTheOther((3, 7), (2, 8)).Should().BeTrue();
        Day04.OneAssignmentContainsTheOther((2, 8), (3, 7)).Should().BeTrue();
        
        Day04.OneAssignmentContainsTheOther((1, 5), (2, 8)).Should().BeFalse();
        Day04.OneAssignmentContainsTheOther((2, 8), (1, 5)).Should().BeFalse();
    }
    
    [Test]
    public void ExamplePart1()
    {
        Day04.Solve("Day04Example.txt".ReadAll().LinesToString()).Should().Be(2);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day04.Solve("Day04.txt".ReadAll().LinesToString()));
    }

    [Test]
    public void ValidatesIfAssignmentsOverlap()
    {
        Day04.AssignmentsOverlap((5, 7), (7, 9)).Should().BeTrue();
        Day04.AssignmentsOverlap((7, 9), (5, 7)).Should().BeTrue();
        Day04.AssignmentsOverlap((2, 8), (3, 7)).Should().BeTrue();
        
        Day04.AssignmentsOverlap((2, 3), (4, 5)).Should().BeFalse();
        Day04.AssignmentsOverlap((4, 5), (2, 3)).Should().BeFalse();
    }
    
    [Test]
    public void ExamplePart2()
    {
        Day04.SolvePart2("Day04Example.txt".ReadAll().LinesToString()).Should().Be(4);
    }

    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day04.SolvePart2("Day04.txt".ReadAll().LinesToString()));
    }
}