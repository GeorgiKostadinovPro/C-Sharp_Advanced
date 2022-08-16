namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<int> coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            int targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> coinsCount = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {coinsCount.Sum(c => c.Value)}");
  
            foreach (var coin in coinsCount)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> coinsCount = new Dictionary<int, int>();

            while (targetSum > 0)
            {
                if (coins.Count == 0)
                {
                    break;
                }

                int maxCoin = coins.Max();

                int currentCoinCount = targetSum / maxCoin;

                if (currentCoinCount == 0)
                {
                    coins.Remove(maxCoin);
                    continue;
                }

                int subtractor = maxCoin * currentCoinCount;
                targetSum -= subtractor;

                if (!coinsCount.ContainsKey(maxCoin))
                {
                    coinsCount.Add(maxCoin, currentCoinCount);
                }

                coins.Remove(maxCoin);
            }

            if (targetSum > 0)
            {
                throw new InvalidOperationException();
            }

            return coinsCount;
        }
    }
}