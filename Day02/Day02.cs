namespace AdventOfCode2022.Day02;

public class Day02
{
    private static List<(char Move, char Beats, char Looses, int Points)> rules = new()
    {
        new() { Move = 'A', Beats = 'C', Points = 1 },
        new() { Move = 'B', Beats = 'A', Points = 2 },
        new() { Move = 'C', Beats = 'B', Points = 3 }
    };
    
    public static int Solve(string input, bool part2)
    {
        return input.Split("\r\n")
            .Select(x => x.Replace(" ", ""))
            .Select(x => GetRoundPoints(x[0], rules.Single(y =>
            {
                if (part2)
                {
                    var elfMove = x[0];
                    var instruction = x[1];
                    return instruction switch
                    {
                        'X' => elfMove != y.Move && elfMove != y.Beats,
                        'Y' => y.Move == elfMove,
                        'Z' => y.Beats == elfMove
                    };
                }

                return y.Move == (char)(x[1] - 23);
            })))
            .Sum();
    }

    private static int GetRoundPoints(char elfMove, (char Move, char Beats, char Looses, int Points) playerMove)
    {
        if (playerMove.Move == elfMove) return playerMove.Points + 3;
        if (playerMove.Beats == elfMove) return playerMove.Points + 6;
        return playerMove.Points;
    }
}