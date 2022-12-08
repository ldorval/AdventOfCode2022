namespace AdventOfCode2022.Day08;

public class Day08
{
    public static int SolvePart1(List<string> input)
    {
        var linesOfTrees = BuildTreeList(input);
        var visibleTrees = new List<Tree>();
        
        foreach (var line in linesOfTrees)
        {
            visibleTrees.AddRange(AddVisibleTrees(line, visibleTrees));
            visibleTrees.AddRange(AddVisibleTrees(Enumerable.Reverse(line).ToList(), visibleTrees));
        }

        for (var i = 0; i < linesOfTrees.First().Count; i++)
        {
            var column = linesOfTrees.Select(x => x[i]).ToList();
            visibleTrees.AddRange(AddVisibleTrees(column, visibleTrees));
            visibleTrees.AddRange(AddVisibleTrees(Enumerable.Reverse(column).ToList(), visibleTrees));
        }
        
        return visibleTrees.Count;
    }

    public static int SolvePart2(List<string> input)
    {
        var linesOfTrees = BuildTreeList(input);
        var scenicScores = new List<int>();

        for (var y = 0; y < linesOfTrees.Count; y++)
        {
            for (var x = 0; x < linesOfTrees[y].Count; x++)
            {
                var left = GetVisibleTreeCountX(linesOfTrees, x, y, -1);
                var right = GetVisibleTreeCountX(linesOfTrees, x, y, 1);
                var up = GetVisibleTreeCountY(linesOfTrees, x, y, -1);
                var down = GetVisibleTreeCountY(linesOfTrees, x, y, 1);
                scenicScores.Add(left * right * up * down);
            }
        }

        return scenicScores.Max();
    }
    
    private static int GetVisibleTreeCountY(List<List<Tree>> linesOfTrees, int x, int y, int step)
    {
        var i = y + step;
        var count = 0;
        while (i >= 0 && i < linesOfTrees.Count)
        {
            if (linesOfTrees[i][x].Height < linesOfTrees[y][x].Height)
                count++;
            else
                return count + 1;
            i += step;
        }

        return count;
    }

    private static int GetVisibleTreeCountX(List<List<Tree>> linesOfTrees, int x, int y, int step)
    {
        var i = x + step;
        var count = 0;
        while (i >= 0 && i < linesOfTrees.First().Count)
        {
            if (linesOfTrees[y][i].Height < linesOfTrees[y][x].Height)
                count++;
            else
                return count + 1;
            i += step;
        }

        return count;
    }

    private static List<List<Tree>> BuildTreeList(List<string> input)
    {
        return input.Select(x => x.Select(y => new Tree{ Height = Convert.ToInt32(y.ToString()), Id = Guid.NewGuid()}).ToList()).ToList();
    }

    private static IEnumerable<Tree> AddVisibleTrees(List<Tree> line, List<Tree> visibleTrees)
    {
        var maxHeightSoFar = -1;
        
        foreach (var tree in line)
        {
            if (tree.Height > maxHeightSoFar)
            {
                maxHeightSoFar = tree.Height;
                if (visibleTrees.All(x => x.Id != tree.Id))
                {
                    yield return tree;
                }
            }
        }
    }
}

public class Tree
{
    public Guid Id { get; set; }
    public int Height { get; set; }
}