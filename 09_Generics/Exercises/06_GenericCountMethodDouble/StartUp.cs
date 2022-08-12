using System;
using System.Linq;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                box.Items.Add(number);
            }

            double numberToCompare = double.Parse(Console.ReadLine());

            int count = box.Count(numberToCompare);
            Console.WriteLine(count);
        }
    }
}
