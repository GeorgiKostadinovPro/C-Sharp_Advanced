﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Peter", 20);
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
