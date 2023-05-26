namespace StoneGameII
{
    internal class Program
    {
        public class StoneGame
        {
            private int DFS(int[] piles, int[][][] dp, int player, int i, int m)
            {
                if (i >= piles.Length)
                {
                    return 0;
                }
                if (dp[player][i][m] != -1)
                {
                    return dp[player][i][m];
                }
                int result = player == 1 ? int.MaxValue : -1;
                int possibleSum = 0;
                for (int x = 1; x <= Math.Min(2 * m, piles.Length - i); ++x)
                {
                    possibleSum += piles[i + x - 1];
                    if (player == 0)
                    {
                        result = Math.Max(result, possibleSum + DFS(piles, dp, 1, i + x, Math.Max(m, x)));
                    }
                    else
                    {
                        result = Math.Min(result, DFS(piles, dp, 0, i + x, Math.Max(m, x)));
                    }
                }
                dp[player][i][m] = result;
                return dp[player][i][m];
            }

            public int StoneGameII(int[] piles)
            {
                int n = piles.Length;
                int[][][] dp = new int[2][][];
                for (int i = 0; i < 2; ++i)
                {
                    dp[i] = new int[n + 1][];
                    for (int j = 0; j <= n; ++j)
                    {
                        dp[i][j] = new int[n + 1];
                        Array.Fill(dp[i][j], -1);
                    }
                }
                return DFS(piles, dp, 0, 0, 1);
            }
        }
        
        static void Main(string[] args)
        {
            StoneGame stoneGame = new();
            Console.WriteLine(stoneGame.StoneGameII(new int[] { 2, 7, 9, 4, 4 }));
            Console.WriteLine(stoneGame.StoneGameII(new int[] { 1, 2, 3, 4, 5, 100 }));
        }
    }
}