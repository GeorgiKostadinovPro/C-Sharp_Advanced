﻿using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int str = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(str);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
