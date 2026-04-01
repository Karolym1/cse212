using System.Collections;

public static class Recursion
{
    // -------------------------
    // Problem 1
    // -------------------------
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    // -------------------------
    // Problem 2
    // -------------------------
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char c in letters)
        {
            if (!word.Contains(c))
            {
                PermutationsChoose(results, letters, size, word + c);
            }
        }
    }

    // -------------------------
    // Problem 3
    // -------------------------
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;

        return ways;
    }

    // -------------------------
    // Problem 4
    // -------------------------
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string withZero = pattern.Substring(0, index) + "0" + pattern.Substring(index + 1);
        string withOne = pattern.Substring(0, index) + "1" + pattern.Substring(index + 1);

        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    // -------------------------
    // Problem 5
    // -------------------------
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Correct method signature (THIS was your error)
        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        // Reached end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        // Explore all directions
        SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
    }
}