using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Bombs
{
    public class Program
    {
        private static int DATURA_BOMBS = 40;
        private static int CHERRY_BOMBS = 60;
        private static int SMOKE_DECOY_BOMBS = 120;


        public static void Main(string[] args)
        {
            int[] bomb_effects = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bomb_casings = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> effects = new Queue<int>(bomb_effects);
            Stack<int> casings = new Stack<int>(bomb_casings);

            int daturaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;

            while (effects.Count > 0 && casings.Count > 0)
            {
                int sum = effects.Peek() + casings.Peek();

                if (sum != DATURA_BOMBS && sum != CHERRY_BOMBS && sum != SMOKE_DECOY_BOMBS)
                {
                    int toReduce = casings.Pop();
                    toReduce -= 5;
                    casings.Push(toReduce);
                }

                if (sum == DATURA_BOMBS)
                {
                    daturaCount++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (sum == CHERRY_BOMBS)
                {
                    cherryCount++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (sum == SMOKE_DECOY_BOMBS)
                {
                    smokeCount++;
                    effects.Dequeue();
                    casings.Pop();
                }

                if (cherryCount >= 3 && daturaCount >= 3 && smokeCount >= 3)
                {
                    break;
                }
            }

            if (daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            string effectsOutput = effects.Count > 0 ? $"Bomb Effects: {string.Join(", ", effects)}" : "Bomb Effects: empty";

            Console.WriteLine(effectsOutput);

            string casingsOutput = casings.Count > 0 ? $"Bomb Casings: {string.Join(", ", casings)}" : "Bomb Casings: empty";

            Console.WriteLine(casingsOutput);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cherry Bombs: {cherryCount}");
            sb.AppendLine($"Datura Bombs: {daturaCount}");
            sb.AppendLine($"Smoke Decoy Bombs: {smokeCount}");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
