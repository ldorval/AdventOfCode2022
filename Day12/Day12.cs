using System.Drawing;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace AdventOfCode2022.Day12;

public class Day12
{
    private List<string> map;
    private Graph<int, string> graph;
    private List<(int id, char height, Point point)> nodes = new();

    public Day12(List<string> map)
    {
        this.map = map;
        BuildNodeList();
        BuildGraph();
        ConnectPoints();
    }

    public int SolvePart1()
    {
        var start = nodes.Single(x => x.height == 'S');
        var end = nodes.Single(x => x.height == 'E');
        var result = graph.Dijkstra((uint)start.id, (uint)end.id);
        return result.GetPath().Count() - 1;
    }

    public int SolvePart2()
    {
        var end = nodes.Single(x => x.height == 'E');
        return nodes.Where(x => x.height == 'a')
            .Select(x => graph.Dijkstra((uint)x.id, (uint)end.id).GetPath().Count() - 1).ToList()
            .Where(x => x != -1)
            .Min();
    }

    private void ConnectPoints()
    {
        foreach (var node in nodes)
        {
            var possibleDirections = GetPossibleDirections(node);
            possibleDirections.ForEach(x => graph.Connect((uint)node.id, (uint)x.id, 1, null));
        }
    }

    private List<(int id, char height, Point point)> GetPossibleDirections((int id, char height, Point point) node)
    {
        return new List<Point>
            {
                node.point with { X = node.point.X - 1 }, node.point with { X = node.point.X + 1 },
                node.point with { Y = node.point.Y - 1 }, node.point with { Y = node.point.Y + 1 }
            }.Where(coordinate => coordinate.X >= 0 && coordinate.Y >= 0)
            .Where(coordinate => coordinate.X < map.First().Length && coordinate.Y < map.Count)
            .Where(coordinate =>
            {
                var currentCharHeight = map[coordinate.Y][coordinate.X] == 'E' ? 'z' : map[coordinate.Y][coordinate.X];
                var nodeCharHeight = node.height == 'S' ? 'a' : node.height;
                return currentCharHeight - nodeCharHeight <= 1;
            })
            .Select(coordinate => nodes.Single(x => x.point.X == coordinate.X && x.point.Y == coordinate.Y))
            .ToList();
    }

    private void BuildGraph()
    {
        graph = new Graph<int, string>();
        nodes.ForEach(x => graph.AddNode(x.id));
    }

    private void BuildNodeList()
    {
        graph = new Graph<int, string>();
        var counter = 1;
        
        for (var y = 0; y < map.Count; y++)
        {
            for (var x = 0; x < map.First().Length; x++)
            {
                nodes.Add((counter, map[y][x], new Point(x, y)));
                counter++;   
            }
        }
    }
}