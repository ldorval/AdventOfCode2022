namespace AdventOfCode2022.Day11;

public class Day11
{
    public static long Solve(List<Monkey> monkeys, int rounds)
    {
        var commonDivider = monkeys.Aggregate((long)1, (a, b) => a * b.DivisibleBy);
        
        Enumerable.Range(0, rounds).ToList().ForEach(_ =>
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items)
                {
                    monkey.InspectedCount++;
                    var newItem = rounds == 20 ? monkey.Operation(item) / 3 : monkey.Operation(item) % commonDivider;

                    if (newItem % monkey.DivisibleBy == 0)
                        monkeys.Single(x => x.Id == monkey.MonkeyWhenTrue).Items.Add(newItem);
                    else
                        monkeys.Single(x => x.Id == monkey.MonkeyWhenFalse).Items.Add(newItem);
                }
                
                monkey.Items.Clear();
            }
        });

        return monkeys.OrderByDescending(x => x.InspectedCount).Take(2).Aggregate(1l, (a, b) => a * b.InspectedCount);
    }
}

public class Monkey
{
    public int Id { get; set; }
    public List<long> Items { get; set; }
    public long DivisibleBy { get; set; }
    public int MonkeyWhenTrue { get; set; }
    public int MonkeyWhenFalse { get; set; }
    public Func<long, long> Operation { get; set; }
    public long InspectedCount { get; set; }
}