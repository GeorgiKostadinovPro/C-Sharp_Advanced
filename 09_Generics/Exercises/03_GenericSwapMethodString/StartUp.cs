using System;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
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
