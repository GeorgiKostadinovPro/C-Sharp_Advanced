using System;

namespace DoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();

            Console.WriteLine("Enter commands in the format: {commandName} {element} - optional.");
            Console.WriteLine("Valid commands are:");
            Console.WriteLine("AddFirst {element} - adds element at the start of the collection.");
            Console.WriteLine("AddLast {element} - adds element at the end of the collection.");
            Console.WriteLine("RemoveFirst - removes the first element in the collection and returns it.");
            Console.WriteLine("RemoveLast - removes the last element in the collection and returns it.");
            Console.WriteLine($"Count - returns the number of elements in the collection.");
            Console.WriteLine("Contains {element} - checks of element exists in the collection and return true or false.");
            Console.WriteLine("ToArray - return a new array with the elements from the collection.");
            Console.WriteLine("End - stops the programme and prints the last state of the list.");

            while (true)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    
                    string command = cmdArgs[0];
                    
                    if (command == "End")
                    {
                        Console.WriteLine("Final state:");
                        doublyLinkedList.ForEach(el => Console.WriteLine(el));
                        Environment.Exit(0);
                    }
                    
                    if (command == "AddFirst")
                    {
                        string element = cmdArgs[1];

                        doublyLinkedList.AddFirst(element);
                    }
                    else if (command == "AddLast")
                    {
                        string element = cmdArgs[1];

                        doublyLinkedList.AddLast(element);
                    }
                    else if (command == "RemoveFirst")
                    {
                        string removedElement = doublyLinkedList.RemoveFirst();

                        Console.WriteLine(removedElement);
                    }
                    else if (command == "RemoveLast")
                    {
                        string removedElement = doublyLinkedList.RemoveLast();

                        Console.WriteLine(removedElement);
                    }
                    else if (command == "Count")
                    {
                        int count = doublyLinkedList.Count;

                        Console.WriteLine($"Number of elements: {count}");
                    }
                    else if (command == "Contains")
                    {
                        string elementToFind = cmdArgs[1];

                        bool isFound = doublyLinkedList.Contains(elementToFind);

                        Console.WriteLine($"Is found: {isFound}");
                    }
                    else if (command == "ToArray")
                    {
                        string[] array = doublyLinkedList.ToArray();
                        Console.WriteLine($"[ {string.Join(", ", array)} ]");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
