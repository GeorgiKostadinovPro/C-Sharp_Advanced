using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> iterator = null;
            string line = string.Empty;

            while (!(line = Console.ReadLine()).Contains("END"))
            {
                string[] commands = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = commands[0];

                switch (action)
                {
                    case "Create":
                        List<string> list = commands.Skip(1).ToList();
                        iterator = new ListyIterator<string>(list);
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "PrintAll":
                        foreach (var element in iterator)
                        {
                            Console.Write(element + " ");
                        }

                        Console.WriteLine();
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (InvalidOperationException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                }
            }
        }
    }
}
