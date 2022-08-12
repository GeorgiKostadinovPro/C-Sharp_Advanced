using System;
using System.Linq;

namespace GenericCountMethodString
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

            string stringToCompare = Console.ReadLine();

            int count = box.Count(stringToCompare);
            Console.WriteLine(count);
        }
    }
}
