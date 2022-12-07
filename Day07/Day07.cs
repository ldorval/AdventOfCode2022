namespace AdventOfCode2022.Day07;

public class Day07
{
    public static long SolvePart1(List<string> lines)
    {
        var dirs = BuildDirectoryList(lines);
        return dirs.Select(x => GetDirectoryTotalSize(x.Key, dirs)).Where(x => x < 100000).Sum();
    }

    public static long SolvePart2(List<string> lines)
    {
        var dirs = BuildDirectoryList(lines);
        var neededSpace = 30000000 - (70000000 - GetDirectoryTotalSize("/", dirs));
        return dirs.Select(x => GetDirectoryTotalSize(x.Key, dirs)).Where(x => x >= neededSpace).Min();
    }

    public static Dictionary<string, long> BuildDirectoryList(List<string> lines)
    {
        lines = lines.Where(x => !x.StartsWith("dir")).ToList();
        var directories = new Dictionary<string, long> { { "/", 0 } };
        var currentPath = "";

        for (var i = 0; i < lines.Count; i++)
        {
            if (lines[i] == "$ cd /") currentPath = "/";
            else if (lines[i] == "$ cd ..") currentPath = GetParentPath(currentPath);
            else if (lines[i].StartsWith("$ cd"))
            {
                currentPath += lines[i].Split(" ")[2] + "/";
                directories.Add(currentPath, 0);
            }
            else if (lines[i] == "$ ls") CalculateDirectorySize(directories, currentPath, lines, i);
        }

        return directories;
    }

    public static long GetDirectoryTotalSize(string path, Dictionary<string, long> dirs)
    {
        return dirs.Where(x => x.Key.StartsWith(path)).Sum(x => x.Value);
    }

    private static void CalculateDirectorySize(Dictionary<string, long> dirs, string currentPath, List<string> lines, int lineIndex)
    {
        lineIndex++;
        
        while (lineIndex < lines.Count && !lines[lineIndex].StartsWith("$"))
        {
            dirs[currentPath] += Convert.ToInt64(lines[lineIndex].Split(" ")[0]);
            lineIndex++;
        }
    }

    public static string GetParentPath(string currentPath)
    {
        var dirArray = currentPath.Trim('/').Split("/").ToList().SkipLast(1).ToList();
        return dirArray.Count == 0 ? "/" : $"/{string.Join("/", dirArray)}/";
    }
}