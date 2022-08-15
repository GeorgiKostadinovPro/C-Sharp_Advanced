using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_TheFightForGondor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int wavesOfOrcs = int.Parse(Console.ReadLine());

            Queue<int> platesOfAragonsDefense = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            List<int> finalOrcs = new List<int>();

            for (int i = 1; i <= wavesOfOrcs; i++)
            {
                int[] orcs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Stack<int> orcsWarriors = new Stack<int>(orcs);

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    platesOfAragonsDefense.Enqueue(newPlate);
                }

                while (platesOfAragonsDefense.Count > 0 && orcsWarriors.Count > 0)
                {
                    int currPlateDefense = platesOfAragonsDefense.Peek();
                    int currOrcWarrior = orcsWarriors.Peek();

                    if (currOrcWarrior > currPlateDefense)
                    {
                        platesOfAragonsDefense.Dequeue();
                        currOrcWarrior -= currPlateDefense;
                        orcsWarriors.Pop();
                        orcsWarriors.Push(currOrcWarrior);
                    }
                    else if (currPlateDefense > currOrcWarrior)
                    {
                        orcsWarriors.Pop();
                        currPlateDefense -= currOrcWarrior;
                        var items = platesOfAragonsDefense.Skip(1).ToArray();
                        platesOfAragonsDefense.Clear();
                        platesOfAragonsDefense.Enqueue(currPlateDefense);
                        foreach (var item in items)
                        {
                            platesOfAragonsDefense.Enqueue(item);
                        }
                    }
                    else
                    {
                        orcsWarriors.Pop();
                        platesOfAragonsDefense.Dequeue();
                    }
                }

                finalOrcs.AddRange(orcsWarriors);

                if (platesOfAragonsDefense.Count <= 0)
                {
                    break;
                }
            }

            if (finalOrcs.Count > 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", finalOrcs)}");
            }
            else if (platesOfAragonsDefense.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesOfAragonsDefense)}");
            }
        }
    }
}
