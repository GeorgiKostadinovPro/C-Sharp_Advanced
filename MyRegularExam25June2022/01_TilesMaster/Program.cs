using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_TilesMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] areasWhiteTiles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] areasGreyTiles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<int, string> locations = new Dictionary<int, string>()
            {
                { 40, "Sink"},
                { 50, "Oven"},
                { 60, "Countertop"},
                { 70, "Wall"},
            };

            Dictionary<string, int> locationsTilesCount = new Dictionary<string, int>()
            {
                { "Sink", 0},
                { "Oven", 0},
                { "Countertop", 0},
                { "Wall", 0},
                { "Floor", 0},
            };

            Stack<int> whiteTiles = new Stack<int>(areasWhiteTiles);
            Queue<int> greyTiles = new Queue<int>(areasGreyTiles);

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int whiteTile = whiteTiles.Peek();
                int greyTile = greyTiles.Peek();

                if (whiteTile == greyTile)
                {
                    int newTile = whiteTile + greyTile;

                    if (locations.ContainsKey(newTile))
                    {
                        string area = locations[newTile];
                        locationsTilesCount[area]++;
                    }
                    else
                    {
                        locationsTilesCount["Floor"]++;
                    }

                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    whiteTile /= 2;
                    whiteTiles.Pop();
                    whiteTiles.Push(whiteTile);
                    greyTiles.Dequeue();
                    greyTiles.Enqueue(greyTile);
                }
            }

            string whiteTilesResult = whiteTiles.Count > 0 ?
                $"White tiles left: {string.Join(", ", whiteTiles)}" :
                "White tiles left: none";

            string greyTilesResult = greyTiles.Count > 0 ?
               $"Grey tiles left: {string.Join(", ", greyTiles)}" :
               "Grey tiles left: none";

            Console.WriteLine(whiteTilesResult);
            Console.WriteLine(greyTilesResult);

            foreach (var location in locationsTilesCount.Where(t => t.Value > 0).OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}