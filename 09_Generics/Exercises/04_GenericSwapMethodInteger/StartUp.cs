﻿using System;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int str = int.Parse(Console.ReadLine());
                box.Items.Add(str);
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box.ToString());
        }
    }
}
