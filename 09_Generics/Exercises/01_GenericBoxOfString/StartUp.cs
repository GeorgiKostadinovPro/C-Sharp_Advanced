﻿using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();

                Box<string> box = new Box<string>(str);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
