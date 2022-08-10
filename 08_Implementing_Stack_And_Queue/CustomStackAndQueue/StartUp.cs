using System;

namespace CustomStackAndQueue
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // First step to initialize our MyList class
            MyList<int> myList = new MyList<int>(3);

            // Second step to add to the list to implement •void Add(int element) 

            myList.Add(5);
            Console.WriteLine($"Adding element {myList[0]}");
            myList.Add(6);
            Console.WriteLine($"Adding element {myList[1]}");
            myList.Add(69);
            Console.WriteLine($"Adding element {myList[2]}");
            myList.Add(6);
            Console.WriteLine($"Adding element {myList[3]}");
            Console.WriteLine($"List initial count after adding elements {myList.Count}");
            int removedItem = myList.RemoveAt(2);
            Console.WriteLine($"Removed element {removedItem} at index 2");
            Console.WriteLine($"List count after removing element {myList.Count}");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine($"current element {myList[i]}");
            }

            Console.WriteLine($"is number 69 on the list {myList.Contains(69)}");
            Console.WriteLine($"is number 6 on the list {myList.Contains(6)}");

            Console.WriteLine($"Testing Clear method");
            myList.Clear();
            Console.WriteLine($"List count after clear method {myList.Count}");

            // TESTING THE INSERT METHOD
            var testInsert = new MyList<int>();
            testInsert.Add(1);
            testInsert.Add(2);
            testInsert.Insert(1, 5);
            Console.WriteLine($"Inserted number at index 1 is now {testInsert[1]}");
            for (int i = 0; i < testInsert.Count; i++)
            {
                Console.Write($"{testInsert[i]} ");
            }

            Console.WriteLine();

            // TESTING THE SWAP METHOD
            var swapTest = new MyList<int>();
            swapTest.Add(1);
            swapTest.Add(2);
            Console.WriteLine($"Swamp test ELEMENTS");
            for (int i = 0; i < swapTest.Count; i++)
            {
                Console.Write($"{swapTest[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine($"After Swap method");
            swapTest.Swap(0, 1);
            for (int i = 0; i < swapTest.Count; i++)
            {
                Console.Write($"{swapTest[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine("TESTING OF STACK");
            Console.WriteLine();
            // ===================================STACK===========================
            Console.WriteLine("-----------------------------STACK-----------------------");
            MyStack<int> myStack = new MyStack<int>();

            myStack.Push(10);
            myStack.Push(20);
            Console.WriteLine(myStack.Count);
            Console.WriteLine(myStack.Peek());
            int popedItem = myStack.Pop();
            Console.WriteLine(popedItem);
            Console.WriteLine(myStack.Peek());
            Console.WriteLine(myStack.Count);

            MyStack<int> newStack = new MyStack<int>();

            for (int i = 0; i <= 10; i++)
            {
                newStack.Push(i);
            }

            newStack.ForEach(n => Console.WriteLine($"number: {n}"));
        }
    }
}
