using System.Drawing;

namespace AdventOfCode2022.Day09;

public class Day09
{
    private List<Point> tailPositionHistory = new();
    private List<Point> knots;
    private Dictionary<string, Point> MoveMods = new()
    {
        {"R", new Point(1, 0)},
        {"L", new Point(-1, 0)},
        {"U", new Point(0, -1)},
        {"D", new Point(0, 1)},
    };

    public int Solve(List<string> input, int knotsCount)
    {
        var moves = input
            .Select(x => x.Split(" "))
            .Select(x => (direction: x[0], distance: Convert.ToInt32(x[1])))
            .ToList();

        tailPositionHistory.Add(new Point(0, 0));

        knots = Enumerable.Range(0, knotsCount).Select(_ => new Point(0, 0)).ToList();

        foreach (var move in moves)
        {
            var mod = MoveMods[move.direction];
            Enumerable.Range(0, move.distance).ToList().ForEach(_ =>
            {
                knots[0] = new Point(knots[0].X + mod.X, knots[0].Y + mod.Y);
                for (var j = 1; j < knots.Count; j++)
                {
                    Move(j);
                }
                
                AddTailPosition(knots.Last());
            });
        }

        return tailPositionHistory.Count;
    }

    private void Move(int indexCurrentKnot)
    {
        var diffX = knots[indexCurrentKnot - 1].X - knots[indexCurrentKnot].X;
        var diffY = knots[indexCurrentKnot - 1].Y - knots[indexCurrentKnot].Y;

        if (Math.Abs(diffX) > 1)
        {
            var yMod = CalculateFollowingKnotMod(diffY);
            knots[indexCurrentKnot] = new Point(knots[indexCurrentKnot].X + CalculateFollowingKnotMod(diffX), knots[indexCurrentKnot].Y + yMod);
        }
        else if (Math.Abs(diffY) > 1)
        {
            var xMod = CalculateFollowingKnotMod(diffX);
            knots[indexCurrentKnot] = new Point(knots[indexCurrentKnot].X + xMod, knots[indexCurrentKnot].Y + CalculateFollowingKnotMod(diffY));
        }
    }

    private int CalculateFollowingKnotMod(int diff) => diff switch { 0 => 0, > 0 => 1, _ => -1 };

    private void AddTailPosition(Point knot)
    {
        if (!tailPositionHistory.Any(x => x.X == knot.X && x.Y == knot.Y))
            tailPositionHistory.Add(knot);
    }
}