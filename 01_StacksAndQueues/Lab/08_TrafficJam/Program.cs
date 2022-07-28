using System;
using System.Collections.Generic;

namespace _08_TrafficJam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfPassingCars = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int passedCarsCount = 0;

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "end")
            {
                if (line == "green")
                {  
                    int passableCars = numberOfPassingCars;

                    while (passableCars > 0)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        string car = cars.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        passedCarsCount++;
                        passableCars--;
                    }
                }
                else 
                {
                    string car = line;
                    cars.Enqueue(car);
                }
            }

            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}
