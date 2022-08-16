namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int rows = int.Parse(Console.ReadLine());

            IList<int[]> sets = new List<int[]>();

            for (int i = 0; i < rows; i++)
            {
                int[] set = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }

            List<int[]> chosenSets = ChooseSets(sets, universe);
            int setsToTake = chosenSets.Count;

            Console.WriteLine($"Sets to take ({setsToTake}):");

            for (int i = 0; i < chosenSets.Count; i++)
            {
                int[] currSet = chosenSets[i];

                Console.WriteLine("{ " + string.Join(", ", currSet) + " }");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> chosenSets = new List<int[]>();

            while (sets.Count > 0 && universe.Count > 0)
            {
                int[] bestSet = sets
                    .OrderByDescending(s => s.Count(el => universe.Contains(el)))
                    .FirstOrDefault();

                for (int i = 0; i < bestSet.Length; i++)
                {
                    int currElement = bestSet[i];

                    if (universe.Contains(currElement))
                    {
                        universe.Remove(currElement);
                    }
                }

                chosenSets.Add(bestSet);
                sets.Remove(bestSet);
            }

            return chosenSets;
        }
    }
}
